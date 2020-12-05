using System;
using System.IO;

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




    }
}
