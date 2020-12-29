using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using static DynaWin.PublicVariables;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;
using System.Windows.Threading;
using Microsoft.Win32;
using System.Diagnostics;
using RefreshTaskbar;

namespace DynaWin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Mutex _mutex = null;

        System.Windows.Forms.NotifyIcon ni = new System.Windows.Forms.NotifyIcon();

        SettingsWindow settingsWindow = new SettingsWindow();

        //create a timer to update theme and wallpaper
        DispatcherTimer UpdaterTimer = new DispatcherTimer();

        //only allow one instance of this application to run
        public MainWindow()
        {
            const string appName = "DynaWin";
            bool createdNew;

            _mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew)
            {
                //app is already running! Exiting the application  
                Application.Current.Shutdown();
                Thread.Sleep(10000);
            }
            
            
            InitializeComponent();


            //create dirs
            Directory.CreateDirectory(DataRootDir);
            Directory.CreateDirectory(DataDynamicThemeRootDir);
            Directory.CreateDirectory(DataDynamicWallpaperRootDir);
            Directory.CreateDirectory(DataDynamicThemeTempDir);
            Directory.CreateDirectory(DataDynamicWallpaperTempDir);

            //set updater timer interval to about 1 minute and start the timer
            UpdaterTimer.Interval = TimeSpan.FromSeconds(60);
            UpdaterTimer.Tick += UpdaterTimer_Tick;
            UpdaterTimer.Start();

            //event handler for settiingswindow closing
            settingsWindow.Closing += SettingsWindow_Closing;

            //minimize this window
            this.WindowState = WindowState.Minimized;

            //don't show this window in taskbar
            this.ShowInTaskbar = false;

            //so basically here is how this tray icon is gonna work:
            //left click -> open settings window
            //right click -> open context menu

            //create and init context menu and menu items-------------------------------------------------
            System.Windows.Forms.ContextMenu TrayMenu = new System.Windows.Forms.ContextMenu();

            System.Windows.Forms.MenuItem OpenDynaWin = new System.Windows.Forms.MenuItem("DynaWin Settings");
            System.Windows.Forms.MenuItem QuitDynaWin = new System.Windows.Forms.MenuItem("Quit DynaWin");

            //add the items
            TrayMenu.MenuItems.Add(OpenDynaWin);
            TrayMenu.MenuItems.Add(QuitDynaWin);

            //create event handlers for the menuitem click
            OpenDynaWin.Click += OpenDynaWin_Click;
            QuitDynaWin.Click += QuitDynaWin_Click;
            //---------------------------------------------------------------------------------------


            //create and init a tray icon------------------------------------------------------------
            ni.Icon = new System.Drawing.Icon(@"Resources\icon.ico");

            //show the notify icon
            ni.Visible = true;

            //show a notification that DynaWin is running
            ni.ShowBalloonTip(1000, "DynaWin is running", "To view or configure DynaWin Settings, " +
                "click on the tray icon", System.Windows.Forms.ToolTipIcon.Info);

            //set the context menu
            ni.ContextMenu = TrayMenu;

            //set the text property to DynaWin
            ni.Text = "DynaWin";

            //create event handlers for mouse_up
            ni.MouseUp += Ni_MouseUp;

            //------------------------------------------------------------------------------------------

            //Check for updates
            CheckForUpdates(false);

            //call the timer event handler
            UpdaterTimer_Tick(null, null);
            
        }

        private void SettingsWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //call the timer event handler
            UpdaterTimer_Tick(null, null);

        }

        //function to get the current time so I don't have to repeat myself
        public DateTime GetCurrentTime()
        {
            DateTime now = DateTime.Now;
            string currentTime = now.ToString("h:mm tt");
            currentTime = currentTime.ToUpper(); //This is to make sure that the AM and PM is upper case

            return DateTime.ParseExact(currentTime, "h:mm tt",
                System.Globalization.CultureInfo.InvariantCulture);
        }


        //function to get battery percentage
        public int GetCurrentBatteryPercentage()
        {
            System.Windows.Forms.PowerStatus powerStatus = System.Windows.Forms.SystemInformation.PowerStatus;
            int BatteryPercentage = (int)(powerStatus.BatteryLifePercent * 100);

            return BatteryPercentage;
        }


        //function to change the system theme
        public void ChangeTheme(string theme, string mode)
        {
            //check the theme
            if (theme == "light")
            {
                //the theme is light
                if (mode == "apps")
                {
                    //the mode is apps, change the app theme
                    Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize",
                   "AppsUseLightTheme", "1", RegistryValueKind.DWord);

                }
                else if (mode == "windows")
                {
                    //the mode is windows, change the system theme
                    Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize",
                       "SystemUsesLightTheme", "1", RegistryValueKind.DWord);
                }

            }
            //check the theme
            else if (theme == "dark")
            {
                //the theme is light
                if (mode == "apps")
                {
                    //the mode is apps, change the app theme
                    Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize",
                   "AppsUseLightTheme", "0", RegistryValueKind.DWord);

                }
                else if (mode == "windows")
                {
                    //the mode is windows, change the system theme
                    Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize",
                       "SystemUsesLightTheme", "0", RegistryValueKind.DWord);
                }

            }

        }

        //function to find closest dateTime
        public DateTime FindClosestDate(IEnumerable<DateTime> source, DateTime target)
        {
            DateTime result = DateTime.MinValue;
            var lowestDifference = TimeSpan.MaxValue;

            foreach (var date in source)
            {
                if (date > target)
                    continue;

                var difference = target - date;

                if (difference <= lowestDifference)
                {
                    lowestDifference = difference;
                    result = date;
                }
            }

            return result;
        }

        //function to get closest number (definitely did not replicate the dfnction for dateTime)
        public int FindClosestNumber(IEnumerable<int> numberList, int targetNumber)
        {
            int result = 0;
            var lowestDifference = int.MaxValue;

            foreach (int number in numberList)
            {
                if (number > targetNumber)
                {
                    continue;
                }

                var difference = targetNumber - number;

                if (difference <= lowestDifference)
                {
                    lowestDifference = difference;
                    result = number;
                }
            }

            return result;

        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SystemParametersInfo(
    UInt32 action, UInt32 uParam, String vParam, UInt32 winIni);

        private static readonly UInt32 SPI_SETDESKWALLPAPER = 0x14;
        private static readonly UInt32 SPIF_UPDATEINIFILE = 0x01;
        private static readonly UInt32 SPIF_SENDWININICHANGE = 0x02;

        public void SetWallpaper(string path)
        {
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path,
                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }


        private void UpdaterTimer_Tick(object sender, EventArgs e)
        {
            //this variable denotes whether to restart explorer
            bool TaskbarRefresh = false;

            //get the current time
            DateTime currentTime = GetCurrentTime();

            //get the current battery percentage
            int currentBatteryPercentage = GetCurrentBatteryPercentage();

            //CHECK DYNAMIC THEME TASKS------------------------------------------------------------------------------

            //iterate through tasks in Dynamic Theme, and then iterate through the actions of the tasks
            foreach (string TaskDirectory in Directory.GetDirectories(DataDynamicThemeRootDir))
            {
                //arrays to store the data from all actions (create 2 categories of lists to run actions from system mode and apps mode)
                var SystemModeTime = new List<DateTime>();
                var SystemModeTheme = new List<string>();

                var AppsModeTime = new List<DateTime>();
                var AppsModeTheme = new List<string>();

                foreach (string TaskAction in Directory.GetFiles(TaskDirectory, "*.txt"))
                {
                    //variables to store data from text file
                    string time = "";
                    string mode = "";
                    string theme = "";

                    //iterate through lines in the taskaction text file.
                    string[] lines = File.ReadAllLines(TaskAction);

                    foreach (string line in lines)
                    {
                        if (line.Contains("time;"))
                        {
                            //remove the stuff after the semicolon 
                            time = line.Substring(line.IndexOf(';') + 1);

                        }
                        else if (line.Contains("mode;"))
                        {
                            //remove the stuff after the semicolon and assign it to the mode variable
                            mode = line.Substring(line.IndexOf(';') + 1);
                        }
                        else if (line.Contains("theme;"))
                        {
                            //remove the stuff after the semicolon and assign it to the theme variable
                            theme = line.Substring(line.IndexOf(';') + 1);
                        }
                        
                    }

                    //check if mode is apps or windows(system) and add the theme and time to the correct list
                    if (mode == "apps")
                    {
                        //add time var and theme var to correct list
                        AppsModeTime.Add(DateTime.ParseExact(time, "h:mm tt",
                            System.Globalization.CultureInfo.InvariantCulture));

                        AppsModeTheme.Add(theme);
                    }
                    else if (mode == "windows")
                    {
                        //add time var and theme var to correct list
                        SystemModeTime.Add(DateTime.ParseExact(time, "h:mm tt",
                            System.Globalization.CultureInfo.InvariantCulture));
         
                        SystemModeTheme.Add(theme);
                    }
                }

                //get the index of the closest time (from the SystemModeTime and AppsModeTime list)
                //do this ONLY if the list is not empty, otherwise shit will go haywire
                try
                {
                    if (SystemModeTime.Count > 0 && SystemModeTheme.Count > 0)
                    {
                        //get the index of the closest time
                        int SystemTimeIndex = SystemModeTime.IndexOf(FindClosestDate(SystemModeTime, currentTime));

                        //use the index to get the appropriate theme from the list
                        string SystemTheme = SystemModeTheme[SystemTimeIndex];

                        //call the change theme function
                        ChangeTheme(SystemTheme, "windows");

                        //set taskbar refresh to true to refresh the taskbar
                        TaskbarRefresh = true;
                    }

                }
                catch
                {
                    //do nothing and try again when the timer ticks again 
                }


                //do the same for the appsMode actions
                try
                {
                    if (AppsModeTime.Count > 0 && AppsModeTheme.Count > 0)
                    {
                        //get the index of the closest time
                        int AppsTimeIndex = AppsModeTime.IndexOf(FindClosestDate(AppsModeTime, currentTime));

                        //use the index to get the appropriate theme from the list
                        string AppsTheme = AppsModeTheme[AppsTimeIndex];

                        //call the change theme function
                        ChangeTheme(AppsTheme, "apps");

                        //set taskbar refresh to true to refresh the taskbar
                        TaskbarRefresh = true;
                    }
                }
                catch
                {
                    //do nothing and try again when the timer ticks again 
                }
            }



            //CHECK DYNAMIC WALLPAPER TASKS------------------------------------------------------------------------------

            //iterate through tasks in dynamic wallpaper root dir
            foreach (string DynamicWallpaperTaskDirectory in Directory.GetDirectories(DataDynamicWallpaperRootDir))
            {
                //arrays to store the data from all actions (create 2 categories of lists to run actions from time mode and battery mode)
                var TimeModeTriggers = new List<DateTime>();
                var TimeModeWallpapers = new List<string>();

                var BatteryModeTriggers = new List<int>();
                var BatteryModeWallpapers = new List<string>();
                
                foreach(string DynamicWallpaperTaskAction in Directory.GetFiles(DynamicWallpaperTaskDirectory, "*.txt"))
                {
                    //variables to store info from text file
                    string wallpaper = "";
                    string mode = "";
                    string trigger = "";

                    //read all lines in the text file
                    string[] lines = File.ReadAllLines(DynamicWallpaperTaskAction);

                    foreach (string line in lines)
                    {
                        if (line.Contains("wallpaper;"))
                        {
                            //remove the stuff after the semicolon and assign it to the wallpaper variable
                            wallpaper = line.Substring(line.IndexOf(';') + 1);
                        }
                        else if (line.Contains("mode;"))
                        {
                            //remove the stuff after the semicolon and assign it to the mode variable
                            mode = line.Substring(line.IndexOf(';') + 1);
                        }
                        else if (line.Contains("trigger;"))
                        {
                            //remove the stuff after the semicolon and assign it to the trigger variable
                            trigger = line.Substring(line.IndexOf(';') + 1);
                        }
                    }

                    /*check the mode, if the mode is battery, add trigger and wallpaper 
                     * to the battery lists, if the mode is time, add the wallpaper and trigger
                     * to the time lists.*/

                    if (mode == "time")
                    {
                        //the mode is time, add to time list
                        TimeModeTriggers.Add(DateTime.ParseExact(trigger, "h:mm tt",
                            System.Globalization.CultureInfo.InvariantCulture));

                        TimeModeWallpapers.Add(wallpaper);
                    }
                    else if (mode == "battery")
                    {
                        //the mode is battery, add to battery list
                        BatteryModeTriggers.Add(int.Parse(trigger));
                        BatteryModeWallpapers.Add(wallpaper);
                    }
                }


                //get the index of the closest time/number(battery percentage) from the the Time and Battery lists
                //do this ONLY if the list is not empty, otherwise shit will go haywire

                try
                {
                    if (TimeModeTriggers.Count > 0 && TimeModeWallpapers.Count > 0)
                    {
                        //get the index of the closet time
                        int ClosestTimeIndex = TimeModeTriggers.IndexOf
                            (FindClosestDate(TimeModeTriggers, currentTime));

                        //use the index to get the appropriate wallpaper from the wallpaper list
                        string timeWallpaperPath = TimeModeWallpapers[ClosestTimeIndex];

                        //change wallpaper
                        SetWallpaper(timeWallpaperPath);

                        //set TaskbarRefresh to true to update the taskbar
                        TaskbarRefresh = true;

                    }
                }
                catch
                {
                    //do nothing and try again when the timer ticks again
                }


                //do the same for battery mode
                try
                {
                    if (BatteryModeTriggers.Count > 0 && BatteryModeWallpapers.Count > 0)
                    {
                        //get the index of the closest number from the list (compared to battery percentage)
                        int ClosestBatteryPercentageIndex = BatteryModeTriggers.IndexOf
                            (FindClosestNumber(BatteryModeTriggers, currentBatteryPercentage));

                        //use the index to get the appropriate wallpaper from the wallpaper list
                        string batteryWallpaperPath = BatteryModeWallpapers[ClosestBatteryPercentageIndex];

                        //change wallpaper
                        SetWallpaper(batteryWallpaperPath);

                        //set TaskbarRefresh to true to update the taskbar
                        TaskbarRefresh = true;
                    }
                }
                catch
                {
                    //do nothing and try again when the timer ticks again
                }


            }



            if (TaskbarRefresh == true)
            {
                //refresh the taskbar
                RefreshTaskbarClass refreshTaskbarClass = new RefreshTaskbarClass();
                refreshTaskbarClass.RefreshTaskbar();
            }
        }

        

        private void QuitDynaWin_Click(object sender, EventArgs e)
        {
            //hide and dispose the notify icon
            ni.Visible = false;
            ni.Icon = null;
            ni.Dispose();

            //quit the application
            Application.Current.Shutdown();
        }

        
        private void OpenDynaWin_Click(object sender, EventArgs e)
        {
            //check if settingswindow is open, if it is, just activate the window
            //if not, open the window

            
            if (SettingsWindowInstances == 0)
            {
                //set the settingswindowinstances to 1 so that 
                //another instance of settings window cannot open
                SettingsWindowInstances = 1;

                //show the window
                settingsWindow.Show();

                //call the timer event handler
                UpdaterTimer_Tick(null, null);
            }
            else
            {
                //activate settingswindow
                settingsWindow.Activate();

                //call the timer event handler
                UpdaterTimer_Tick(null, null);

            }



        }

        private void Ni_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //check if left click
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //check if settingswindow is open, if it is, just activate the window
                //if not, open the window


                if (SettingsWindowInstances == 0)
                {
                    //set the settingswindowinstances to 1 so that 
                    //another instance of settings window cannot open
                    SettingsWindowInstances = 1;

                    //show the window
                    settingsWindow.Show();

                    //call the timer event handler
                    UpdaterTimer_Tick(null, null);
                }
                else
                {
                    //activate settingswindow
                    settingsWindow.Activate();

                    //call the timer event handler
                    UpdaterTimer_Tick(null, null);

                }

            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //hide and dispose the notify icon
            ni.Visible = false;
            ni.Icon = null;
            ni.Dispose();
        }
    }
}
