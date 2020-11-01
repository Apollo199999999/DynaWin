using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

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

        public static string DataBingWallpaperRootDir = Environment.GetFolderPath
            (Environment.SpecialFolder.ApplicationData) + "\\DynaWin\\BingWallpaper\\";



    }
}
