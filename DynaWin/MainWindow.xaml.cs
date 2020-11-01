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

namespace DynaWin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Mutex _mutex = null;

        System.Windows.Forms.NotifyIcon ni = new System.Windows.Forms.NotifyIcon();

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
            Directory.CreateDirectory(DataBingWallpaperRootDir);


            /*Next, we must check if the DataDirs does NOT contain state.txt.
             If it does not, create a config.txt for all of the options and set all options for the dynamic stuff 
            to disabled */
            if (!File.Exists(System.IO.Path.Combine(DataDynamicThemeRootDir, "state.txt")))
            {
                //create a text file in data dir
                var StateFile = File.CreateText(System.IO.Path.Combine(DataDynamicThemeRootDir, "state.txt"));

                //close the text document otherwise writing to the file won't work
                StateFile.Close();

                //write 'disabled' in the text file
                // Write file using StreamWriter  
                using (StreamWriter writer = new StreamWriter
                    (System.IO.Path.Combine(DataDynamicThemeRootDir, "state.txt")))
                {
                    writer.WriteLine("disabled");
                }
                
            }
            if (!File.Exists(System.IO.Path.Combine(DataDynamicWallpaperRootDir, "state.txt")))
            {
                //create a text file in data dir
                var StateFile = File.CreateText(System.IO.Path.Combine(DataDynamicWallpaperRootDir, "state.txt"));

                //close the text document otherwise writing to the file won't work
                StateFile.Close();

                //write 'disabled' in the text file
                // Write file using StreamWriter  
                using (StreamWriter writer = new StreamWriter
                    (System.IO.Path.Combine(DataDynamicWallpaperRootDir, "state.txt")))
                {
                    writer.WriteLine("disabled");
                }

            }
            if (!File.Exists(System.IO.Path.Combine(DataBingWallpaperRootDir, "state.txt")))
            {
                //create a text file in data dir
                var StateFile = File.CreateText(System.IO.Path.Combine(DataBingWallpaperRootDir, "state.txt"));

                //close the text document otherwise writing to the file won't work
                StateFile.Close();

                //write 'disabled' in the text file
                // Write file using StreamWriter  
                using (StreamWriter writer = new StreamWriter
                    (System.IO.Path.Combine(DataBingWallpaperRootDir, "state.txt")))
                {
                    writer.WriteLine("disabled");
                }
            }



            /*Next, check if the settings file for Dynamic Theme exists. 
              If it does not, create a blank one with default time*/

            if (!File.Exists(System.IO.Path.Combine(DataDynamicThemeRootDir, "lightthemesettings.txt")))
            {
                //create a text file
                var file = File.CreateText(System.IO.Path.Combine(DataDynamicThemeRootDir, "lightthemesettings.txt"));

                //close the text document
                file.Close();

                //write a default time (8:00 AM) in the text document
                using (StreamWriter writer = new StreamWriter
                    (System.IO.Path.Combine(DataDynamicThemeRootDir, "lightthemesettings.txt")))
                {
                    writer.WriteLine("8:00 AM");
                }

            }

            if (!File.Exists(System.IO.Path.Combine(DataDynamicThemeRootDir, "darkthemesettings.txt")))
            {
                //create a text file
                var file = File.CreateText(System.IO.Path.Combine(DataDynamicThemeRootDir, "darkthemesettings.txt"));

                //close the text document
                file.Close();

                //write a default time (8:00 AM) in the text document
                using (StreamWriter writer = new StreamWriter
                    (System.IO.Path.Combine(DataDynamicThemeRootDir, "darkthemesettings.txt")))
                {
                    writer.WriteLine("8:00 PM");
                }

            }


            //minimize this window
            this.WindowState = WindowState.Minimized;

            //don't show this window in taskbar
            this.ShowInTaskbar = false;

            //so basically here is how this tray icon is gonna work:
            //left click -> open settings window
            //right click -> open context menu

            //create and init context menu and menu items-------------------------------------------------
            System.Windows.Forms.ContextMenu TrayMenu = new System.Windows.Forms.ContextMenu();

            System.Windows.Forms.MenuItem OpenDynaWin = new System.Windows.Forms.MenuItem("Open DynaWin");
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

        SettingsWindow settingsWindow = new SettingsWindow();

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
                //show the window
                settingsWindow.Show();

                //and set the settingswindowinstances to 1 so that 
                //another instance of settings window cannot open
                SettingsWindowInstances = 1;             
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
                    //show the window
                    settingsWindow.Show();

                    //and set the settingswindowinstances to 1 so that 
                    //another instance of settings window cannot open
                    SettingsWindowInstances = 1;
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
