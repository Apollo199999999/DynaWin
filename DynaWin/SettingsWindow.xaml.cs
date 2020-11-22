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
using static DynaWin.PublicVariables;
using System.Runtime.InteropServices;
using System.IO;
using ModernWpf.Controls;
using Microsoft.Win32;

namespace DynaWin
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    /// 


    public partial class SettingsWindow : Window
    {
        
        public SettingsWindow()
        {
            InitializeComponent();
            DynamicThemeListBox.Items.Add("Test");
            DynamicThemeListBox.Items.Add("Testfvkhsfblvjkfbvljfs");
            DynamicThemeListBox.Items.Add("Testvasdlkvjaspdkjsdkl;vjasdvlk;jasd;v");

            //create a timer to update theme
            DispatcherTimer ThemeUpdater = new DispatcherTimer();
            ThemeUpdater.Interval = TimeSpan.FromMilliseconds(100);
            ThemeUpdater.Tick += ThemeUpdater_Tick;
            ThemeUpdater.Start();

        }

        private void ThemeUpdater_Tick(object sender, EventArgs e)
        {
            //check if light theme or dark theme
            bool is_light_mode = true;
            try
            {
                var v = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", "1");
                if (v != null && v.ToString() == "0")
                    is_light_mode = false;
            }
            catch { }

            if (is_light_mode == true)
            {
                //Windows is in light mode
                //change the grid bg image and the logoheader image
                LogoHeader.Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/Resources/icon with text Dark.png"));
                GridBackground.ImageSource = new BitmapImage(new Uri("pack://siteoforigin:,,,/Resources/Background.jpg"));
            }
            else if (is_light_mode == false)
            {
                //Windows is in dark mode
                //change the grid bg image and the logoheader image
                LogoHeader.Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/Resources/icon with text.png"));
                GridBackground.ImageSource = new BitmapImage(new Uri("pack://siteoforigin:,,,/Resources/BackgroundDark.jpg"));
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //dont close the window
            e.Cancel = true;

            //reset the settingswindowinstances var so another settings window can be opened
            SettingsWindowInstances = 0;

            //save settings for everything

            //hide this window
            this.Hide();
        }

        private void DynamicThemeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //check if the selected item is add dynamic theme task btn
            if (DynamicThemeListBox.SelectedItem == AddDynamicThemeTaskBtn)
            {
                //show the add dynamic theme task window
                AddDynamicThemeTask addDynamicThemeTask = new AddDynamicThemeTask();
                addDynamicThemeTask.Owner = this;
                addDynamicThemeTask.ShowDialog();

                //deselect all items from the listbox
                DynamicThemeListBox.UnselectAll();
            }
        }

        private void DynamicWallpaperListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //check if the selected item is add dynamic wallpaper task btn
            if (DynamicWallpaperListBox.SelectedItem == AddDynamicWallpaperTaskBtn)
            {
                //show the add dynamic theme task window
                AddDynamicWallpaperTask addDynamicWallpaperTask = new AddDynamicWallpaperTask();
                addDynamicWallpaperTask.Owner = this;
                addDynamicWallpaperTask.ShowDialog();

                //deselect all items from the listbox
                DynamicWallpaperListBox.UnselectAll();
            }
        }
    }
}
