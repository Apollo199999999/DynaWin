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

            //set the navview selected item
            NavigationView.SelectedItem = DynamicWallpaperItem;

            //make the navframe header not visible
            Style s = new Style();
            s.Setters.Add(new Setter(UIElement.VisibilityProperty, Visibility.Collapsed));
            NavigationFrame.ItemContainerStyle = s;

            //hide the two disabling labels first
            BingWallpaperDisableLabel.Visibility = Visibility.Hidden;
            DynamicWallpaperDisableLabel.Visibility = Visibility.Hidden;

            //add test item
            WallpapersListView.Items.Add("this is a test");
        }

        //function for loading toggle state 
        public void LoadToggleState(string ToggleState, ToggleSwitch toggleSwitch)
        {
            //check if ToggleState is enabled or disabled.
            //If enabled, turn toggleswitch on
            //If disabled, turn toggleswitch off
            if (ToggleState == "disabled") 
            {
                //toggleswitch is off (turn the switch on and off to activate the event handler)
                toggleSwitch.IsOn = true;
                toggleSwitch.IsOn = false;

            }
            else if (ToggleState == "enabled")
            {
                //toggleswitch is on (turn the switch off and on to activate the event handler)
                toggleSwitch.IsOn = false;
                toggleSwitch.IsOn = true;
            }
          
        }

        //function for saving the togglestate
        public void SaveToggleState(string SavePath, ToggleSwitch toggleSwitch)
        {
            //delete the textfile and create a new one
            File.Delete(SavePath);

            //create a text file in data dir
            var StateFile = File.CreateText(SavePath);

            //close the text document otherwise writing to the file won't work
            StateFile.Close();

            //check the state of the toggleswitch
            if (toggleSwitch.IsOn == false || toggleSwitch.IsEnabled == false)
            {
                //the toggleswitch is off, write disabled in text file
                //write 'disabled' in the text file
                // Write file using StreamWriter  
                using (StreamWriter writer = new StreamWriter(SavePath))
                {
                    writer.WriteLine("disabled");
                }
            }
            else if (toggleSwitch.IsOn == true && toggleSwitch.IsEnabled == true)
            {
                //the toggleswitch is on, write disabled in text file
                //write 'enabled' in the text file
                // Write file using StreamWriter  
                using (StreamWriter writer = new StreamWriter(SavePath))
                {
                    writer.WriteLine("enabled");
                }
            }
        }

        //function to read the time from the text document, and set the time in the timepicker
        public void LoadTimePickerTimeFromTextFile(TimePicker timePicker, string TextPath)
        {
            //read the first line from text document
            string timePickerTime = File.ReadLines(TextPath).First();

            //set the time of the timepicker
            timePicker.SetTimeAsString(timePickerTime);
        }

        //function to save the time to text document
        public void SaveTimePickerTimeToTextFile(TimePicker timePicker, string TextPath)
        {
            //delete the text file and create a new one
            File.Delete(TextPath);
            var SaveText = File.CreateText(TextPath);

            //close the text document
            SaveText.Close();

            //write the selected time of thw timepicker in the text file
            using (StreamWriter writer = new StreamWriter(TextPath))
            {
                writer.WriteLine(timePicker.GetSelectedTime());
            }
        }

        //Helper function for enabling or disabling all children in grid
        public void EnableOrDisableControlsInGrid(Grid grid, bool enabled)
        {
            if (enabled == true)
            {
                foreach (Control c in grid.Children)
                {
                    //enable the controls
                    c.IsEnabled = true;
                }
            }
            else if (enabled == false)
            {
                foreach (Control c in grid.Children)
                {
                    //disable the controls
                    c.IsEnabled = false;
                }
            }
        }

        private void NavigationView_SelectionChanged(ModernWpf.Controls.NavigationView sender, ModernWpf.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            //change the tabcontrol tabs (i have no idea how to make this not code spaghetti)
            if (NavigationView.SelectedItem == DynamicWallpaperItem)
            {
                NavigationFrame.SelectedIndex = 0;
            }
            else if (NavigationView.SelectedItem == DynamicThemeItem)
            {
                NavigationFrame.SelectedIndex = 1;
            }
            else if (NavigationView.SelectedItem == DailyBingImageAsDesktopItem)
            {
                NavigationFrame.SelectedIndex = 2;
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //dont close the window
            e.Cancel = true;

            //reset the settingswindowinstances var so another settings window can be opened
            SettingsWindowInstances = 0;

            //save settings for everything

            //Save the selected time in the text file
            SaveTimePickerTimeToTextFile(LightThemeTimePicker,
                System.IO.Path.Combine(DataDynamicThemeRootDir, "lightthemesettings.txt"));

            //Save the selected time in the text file
            SaveTimePickerTimeToTextFile(DarkThemeTimePicker,
                System.IO.Path.Combine(DataDynamicThemeRootDir, "darkthemesettings.txt"));

            //Save the selected time in the text file
            SaveTimePickerTimeToTextFile(SunriseTimePicker,
                System.IO.Path.Combine(DataDynamicWallpaperRootDir, "sunrisetime.txt"));

            //Save the selected time in the text file
            SaveTimePickerTimeToTextFile(SunsetTimePicker,
                System.IO.Path.Combine(DataDynamicWallpaperRootDir, "sunsettime.txt"));


            //save the toggle state
            SaveToggleState(System.IO.Path.Combine(DataDynamicWallpaperRootDir, "state.txt"), 
                WallpaperToggle);

            //save toggle
            SaveToggleState(System.IO.Path.Combine(DataDynamicThemeRootDir, "state.txt"), 
                ThemeToggle);

            //save toggle
            SaveToggleState(System.IO.Path.Combine(DataBingWallpaperRootDir, "state.txt"), 
                BingToggle);

            //hide this window
            this.Hide();
        }

        private void NavigationView_ItemInvoked(ModernWpf.Controls.NavigationView sender, ModernWpf.Controls.NavigationViewItemInvokedEventArgs args)
        {
            //check if it is the settings button
            if (args.IsSettingsInvoked)
            {
                //Go to settings tab
                NavigationFrame.SelectedIndex = 3;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //load the state of the toggle switches from the text file
            string DynamicWallpaperToggleState = File.ReadLines(
                System.IO.Path.Combine(DataDynamicWallpaperRootDir, "state.txt")).First();

            string DynamicThemeToggleState = File.ReadLines(
                System.IO.Path.Combine(DataDynamicThemeRootDir, "state.txt")).First();

            string BingWallpaperToggleState = File.ReadLines(
                System.IO.Path.Combine(DataBingWallpaperRootDir, "state.txt")).First();

            LoadToggleState(DynamicWallpaperToggleState, WallpaperToggle);
            LoadToggleState(DynamicThemeToggleState, ThemeToggle);
            LoadToggleState(BingWallpaperToggleState, BingToggle);

            //set the time of the time picker
            LoadTimePickerTimeFromTextFile(LightThemeTimePicker,
                System.IO.Path.Combine(DataDynamicThemeRootDir, "lightthemesettings.txt"));

            LoadTimePickerTimeFromTextFile(DarkThemeTimePicker,
               System.IO.Path.Combine(DataDynamicThemeRootDir, "darkthemesettings.txt"));

            LoadTimePickerTimeFromTextFile(SunriseTimePicker,
               System.IO.Path.Combine(DataDynamicWallpaperRootDir, "sunrisetime.txt"));

            LoadTimePickerTimeFromTextFile(SunsetTimePicker,
               System.IO.Path.Combine(DataDynamicWallpaperRootDir, "sunsettime.txt"));
        }

        private void WallpaperToggle_Toggled(object sender, RoutedEventArgs e)
        {
            //check if on or off. If On, enable the items in the grid, if Off, disable the items in the grid (also write to text document)
            //SPECIAL CASE: Dyanmic Wallpaper cannot be turned on when Bing Wallpaper is turned on. Add additional checks for that
            if (WallpaperToggle.IsOn == true)
            {
                //the toggle is on, enable the controls in the grid
                EnableOrDisableControlsInGrid(WallpaperGrid, true);

                //disable the bing toggle and show the condescending label
                BingToggle.IsEnabled = false;
                BingWallpaperDisableLabel.Visibility = Visibility.Visible;
            }
            else if (WallpaperToggle.IsOn == false)
            {
                //the toggle is off, disable the controls in the grid
                EnableOrDisableControlsInGrid(WallpaperGrid, false);

                //enable the bing toggle and hide the condescending label
                BingToggle.IsEnabled = true;
                BingWallpaperDisableLabel.Visibility = Visibility.Hidden;
            }

        }

        private void ThemeToggle_Toggled(object sender, RoutedEventArgs e)
        {
            //check if on or off. If On, enable the items in the grid, if Off, disable the items in the grid (also write to text document)
            if (ThemeToggle.IsOn == true)
            {
                //enable controls in grid
                EnableOrDisableControlsInGrid(ThemeGrid, true);
            }
            else if (ThemeToggle.IsOn == false)
            {
                //disable controls in grid
                EnableOrDisableControlsInGrid(ThemeGrid, false);
            }

        }

        private void BingToggle_Toggled(object sender, RoutedEventArgs e)
        {
            //check if on or off. If On, enable the items in the grid, if Off, disable the items in the grid (also write to text document)
            //SPECIAL CASE: Dyanmic Wallpaper cannot be turned on when Bing Wallpaper is turned on. Add additional checks for that
            if (BingToggle.IsOn == true)
            {
                //the toggle is on, enable the controls in the grid
                EnableOrDisableControlsInGrid(BingGrid, true);

                //disable the wallpaper toggle and show the condescending label
                WallpaperToggle.IsEnabled = false;
                DynamicWallpaperDisableLabel.Visibility = Visibility.Visible;
            }
            else if (BingToggle.IsOn == false)
            {
                //the toggle is off, disable the controls in the grid
                EnableOrDisableControlsInGrid(BingGrid, false);

                //enable the wallpaper toggle and hide the condescending label
                WallpaperToggle.IsEnabled = true;
                DynamicWallpaperDisableLabel.Visibility = Visibility.Hidden;
            }

        }

       
    }
}
