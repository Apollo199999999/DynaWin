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
         
            //create a timer to update theme
            DispatcherTimer Updater = new DispatcherTimer();
            Updater.Interval = TimeSpan.FromMilliseconds(100);
            Updater.Tick += Updater_Tick;
            Updater.Start();

        }

        private void Updater_Tick(object sender, EventArgs e)
        {
            //THIS PART IS TO UPDATE THE THEME OF THE APP
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
            //-------------------------------------------------------------------------------------------------

        }

        //Create a function to update the task listbox in settingswindow
        public void UpdateTaskListBox(ListBox listBox, int DynamicThemeOrDynamicDesktop)
        {
            //clear listbox items EXCEPT the first one
            var listBoxFirstItem = listBox.Items[0];
            listBox.Items.Clear();
            listBox.Items.Add(listBoxFirstItem);

            //string to store directory where all the tasks are located
            string TaskDirectories;

            //check where the tasks are stored
            if (DynamicThemeOrDynamicDesktop == 0)
            {
                TaskDirectories = DataDynamicThemeRootDir;
            }
            else
            {
                
                TaskDirectories = DataDynamicWallpaperRootDir;
            }

            //iterate through directories in TaskDirectory, getting the name of the tasks
            foreach (string TaskDirectory in Directory.GetDirectories(TaskDirectories))
            {
                //create a grid, populate it with controls, and add it to the listbox
                Grid TaskGrid = new Grid();
                //I have no idea why you need to minus 30, i do this so that the button fits ok
                TaskGrid.Width = listBox.Width - 30;
                TaskGrid.Height = 30;

                //Create an Image control and display the dynamicthemetaskicon or dynamicwallpapertaskicon
                System.Windows.Controls.Image icon = new System.Windows.Controls.Image();

                //display the correct icon
                if (DynamicThemeOrDynamicDesktop == 0)
                {
                    //display the dynamic theme icon
                    icon.Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/Resources/DynamicThemeTaskIcon.png"));
                }
                else
                {
                    //display the dynamicwallpapericon
                    icon.Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/Resources/DynamicWallpaperTaskIcon.png"));
                }

                icon.Height = 23;
                icon.Width = 23;
                icon.HorizontalAlignment = HorizontalAlignment.Left;

                //create a Label
                Label label1 = new Label();
                label1.Content = new DirectoryInfo(TaskDirectory).Name;
                label1.HorizontalAlignment = HorizontalAlignment.Left;
                label1.VerticalAlignment = VerticalAlignment.Center;
                label1.FontSize = 14;
                label1.FontWeight = FontWeights.Bold;
                label1.Margin = new Thickness(30, 0, 0, 0);
                label1.HorizontalContentAlignment = HorizontalAlignment.Center;

                //create an edit button
                Button MoreBtn = new Button();
                MoreBtn.Content = "\xE712";
                MoreBtn.HorizontalAlignment = HorizontalAlignment.Right;
                MoreBtn.VerticalAlignment = VerticalAlignment.Center;
                MoreBtn.FontFamily = new System.Windows.Media.FontFamily("Segoe MDL2 Assets");
                MoreBtn.FontSize = 14;

                TaskGrid.Children.Add(icon);
                TaskGrid.Children.Add(label1);
                TaskGrid.Children.Add(MoreBtn);

                listBox.Items.Add(TaskGrid);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //update the task listbox
            UpdateTaskListBox(DynamicThemeListBox, 0);
            UpdateTaskListBox(DynamicWallpaperListBox, 1);
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
