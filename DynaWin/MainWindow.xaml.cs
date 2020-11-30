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

            //event handler for settings window closing
            settingsWindow.Closing += SettingsWindow_Closing;

            //set updater timer interval to about 1 minute and start the timer
            UpdaterTimer.Interval = TimeSpan.FromSeconds(60);
            UpdaterTimer.Tick += UpdaterTimer_Tick;
            UpdaterTimer.Start();

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
            ni.Visible = true;

            //set the context menu
            ni.ContextMenu = TrayMenu;

            //set the text property to DynaWin
            ni.Text = "DynaWin";

            //create event handlers for mouse_up
            ni.MouseUp += Ni_MouseUp;
            //------------------------------------------------------------------------------------------
        }

        private void SettingsWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //start the timer again
            UpdaterTimer.Start();
            //call the event handler
            UpdaterTimer_Tick(null, null);
        }

        //function to get the current time so I don't have to repeat myself
        public string GetCurrentTime()
        {
            DateTime now = DateTime.Now;
            string currentTime = now.ToString("h:mm tt");
            currentTime = currentTime.ToUpper(); //This is to make sure that the AM and PM is upper case
           
            return currentTime;
        }

        //function to change the system theme
        public void ChangeSystemTheme(string theme, string mode)
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

        private void UpdaterTimer_Tick(object sender, EventArgs e)
        {
            //get the current time
            string currentTime = GetCurrentTime();

            //iterate through tasks in Dynamic Theme, and then iterate through the actions of the tasks
            foreach (string TaskDirectory in Directory.GetDirectories(DataDynamicThemeRootDir))
            {
                foreach (string TaskAction in Directory.GetFiles(TaskDirectory, "*.txt"))
                {
                    //variables to store data from the text file
                    string time = "";
                    string mode = "";
                    string theme = "";

                    //iterate through lines in the taskaction text file.
                    string[] lines = File.ReadAllLines(TaskAction);
                    foreach (string line in lines)
                    {
                        if (line.Contains("time;"))
                        {
                            //remove the stuff after the semicolon and assign it to the time variable
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

                    //check if time matches the current time
                    if (time == currentTime)
                    {
                        ChangeSystemTheme(theme, mode);
                    }
                }
            }

            //TODO: Implement checking procedures for Dynamic wallpaper here

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

                //call the event handler
                UpdaterTimer_Tick(null, null);

            }
            else
            {
                //activate settingswindow
                settingsWindow.Activate();
                
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

                    //call the event handler
                    UpdaterTimer_Tick(null, null);
                }
                else
                {
                    //activate settingswindow
                    settingsWindow.Activate();

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
