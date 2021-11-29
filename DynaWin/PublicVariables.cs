using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Runtime.InteropServices;
using System.IO;
using System.Net;

namespace DynaWin
{
    static class PublicVariables
    {
        //variable for checking ths instances of settingswindow and to avoid opening a 
        //second instance of settingswindow
        public static int SettingsWindowInstances = 0;

        //vars for directories for storing data
        public static string DataRootDir = Environment.GetFolderPath
            (Environment.SpecialFolder.ApplicationData) + "\\DynaWin\\";

        public static string DataDynamicWallpaperRootDir = Environment.GetFolderPath
            (Environment.SpecialFolder.ApplicationData) + "\\DynaWin\\DynamicWallpaper\\";

        public static string DataDynamicThemeRootDir = Environment.GetFolderPath
            (Environment.SpecialFolder.ApplicationData) + "\\DynaWin\\DynamicTheme\\";

        public static string DataDynamicThemeTempDir = Environment.GetFolderPath
            (Environment.SpecialFolder.ApplicationData) + "\\DynaWin\\Temp\\DynamicTheme";

        public static string DataDynamicWallpaperTempDir = Environment.GetFolderPath
            (Environment.SpecialFolder.ApplicationData) + "\\DynaWin\\Temp\\DynamicWallpaper";

        public static string StarupFolder = Environment.GetFolderPath(Environment.SpecialFolder.Startup);

        //this variable stores the current version of DynaWin
        public static string DynaWinCurrentVersion = "1.0.3";

        //function to see if a second task with the same name exists
        public static bool CheckifTaskNameExists(string targetDirectory, string TaskName)
        {
            //check if another task has the same name as this task

            //get subdirectories in DataDynamicThemeDirectory
            string[] directories = Directory.GetDirectories(targetDirectory);

            //iterate through the directories, and check if the foldername is the same as the TaskName Textbox
            foreach (string directory in directories)
            {
                string directoryName = new DirectoryInfo(directory).Name;

                if (TaskName == directoryName)
                {
                    return true;
                }
                else if (TaskName != directoryName)
                {
                    return false;
                }
            }

            return false;
        }


        //Check Internet Connection Function
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var CheckInternet = new WebClient())
                using (CheckInternet.OpenRead("http://clients3.google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static void CheckForUpdates(bool ShowInfoMessage)
        {
            //check if there is internet connection
            if (CheckForInternetConnection() == true)
            {
                //Check for updates
                var url = "https://pastebin.com/raw/m3m85kbH";
                WebClient client = new WebClient();
                string reply = client.DownloadString(url);

                if (reply != DynaWinCurrentVersion)
                {
                    //this is the output when an update is available. Modify it if you wish

                    //show the messagebox
                    var result = MessageBox.Show("An update is available for DynaWin, " +
                        "would you like to go to our website to download it?", "Update available", 
                        MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        //go to the github page
                        System.Diagnostics.Process.Start("https://github.com/Apollo199999999/DynaWin/releases");

                        //exit the application
                        Application.Current.Shutdown();
                    }
                }
                else if (reply == DynaWinCurrentVersion)
                {
                    //no updates available
                    //only show a messsage if the showinfomessage is true
                    if (ShowInfoMessage == true)
                    {
                        //show a messagebox
                        MessageBox.Show("No updates available for DynaWin.", "You're up to date!", 
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }

            }
            else if (CheckForInternetConnection() == false)
            {
                //show an error message that there is no internet connection (only if showinfomessage is true)
                if (ShowInfoMessage == true)
                {
                    //show error message
                    MessageBox.Show("DynaWin cannot check for updates as there is no internet connection. " +
                    "Connect to the internet and try again", "No internet connection",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }
    }
}
