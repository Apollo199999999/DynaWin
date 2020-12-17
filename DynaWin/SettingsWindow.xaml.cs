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
            Updater.Interval = TimeSpan.FromMilliseconds(1000);
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

                //create a tooltip for the more button
                ToolTip toolTip = new ToolTip();
                toolTip.Content = "More";

                //create a more button
                Button MoreBtn = new Button();

                //set the tooltip service
                MoreBtn.ToolTip = toolTip;
                
                MoreBtn.Content = "\xE712";
                MoreBtn.HorizontalAlignment = HorizontalAlignment.Right;
                MoreBtn.VerticalAlignment = VerticalAlignment.Center;
                MoreBtn.FontFamily = new System.Windows.Media.FontFamily("Segoe MDL2 Assets");
                MoreBtn.FontSize = 18;
                MoreBtn.FontWeight = FontWeights.Bold;
                MoreBtn.Background = System.Windows.Media.Brushes.Transparent;

                //store the filepath in the button tag
                MoreBtn.Tag = TaskDirectory;
                MoreBtn.Click += MoreBtn_Click;
               
                TaskGrid.Children.Add(icon);
                TaskGrid.Children.Add(label1);
                TaskGrid.Children.Add(MoreBtn);

                //add the item to the listbox and unselect all items
                listBox.Items.Add(TaskGrid);
                listBox.UnselectAll();
            }
        }

        private void MoreBtn_Click(object sender, RoutedEventArgs e)
        {
            //init the sender as button
            var MoreBtn = sender as Button;

            //create a context menu
            ContextMenu MenuFlyout = new ContextMenu();


            //create menu items
            MenuItem RemoveItem = new MenuItem();
            RemoveItem.Header = "Delete this task";

            //create the image that will act as the icon for the context menu icon
            System.Windows.Controls.Image RemoveImage = new System.Windows.Controls.Image();
            RemoveImage.Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/Resources/TrashIcon.png"));
            
            //set the icon
            RemoveItem.Icon = RemoveImage;

            //Click event handler
            RemoveItem.Click += RemoveItem_Click;


            //second menu item for editing the task
            MenuItem EditItem = new MenuItem();
            EditItem.Header = "Edit this task";

            //create the image that will act as the icon for the context menu icon
            System.Windows.Controls.Image EditImage = new System.Windows.Controls.Image();
            EditImage.Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/Resources/EditIcon.png"));

            //set the icon
            EditItem.Icon = EditImage;

            //click event handler
            EditItem.Click += EditItem_Click;

            //add the items to the context menu
            MenuFlyout.Items.Add(RemoveItem);
            MenuFlyout.Items.Add(EditItem);

            //show the context menu
            MoreBtn.ContextMenu = MenuFlyout;
            MenuFlyout.PlacementTarget = MoreBtn;
            MenuFlyout.IsOpen = true;

        }

        private void EditItem_Click(object sender, RoutedEventArgs e)
        {
            //cast the sender as MenuItem
            MenuItem EditItem = sender as MenuItem;

            //get the context menu that the menu item belongs to
            ContextMenu MenuFlyout = EditItem.Parent as ContextMenu;

            //get the source control of the context menu
            Button MoreBtn = MenuFlyout.PlacementTarget as Button;

            //get the tag of the button (that's where the directory of the task is stored)
            string TaskDirectory = MoreBtn.Tag.ToString();

            //check if the directory belongs to dynamic theme or dynamic wallpaper
            if (Directory.GetParent(TaskDirectory).Name == "DynamicTheme")
            {
                //The task is a dynamic theme task

                //init a new add dynamic theme task window
                AddDynamicThemeTask addDynamicThemeTask = new AddDynamicThemeTask();

                //set edit mode to true
                addDynamicThemeTask.IsEditMode = true;

                //configure the add dynamic theme task window so that the name and actions are already filled in
                addDynamicThemeTask.TaskNameTextBox.Text = new DirectoryInfo(TaskDirectory).Name;

                //iterate through text files in the directory, filling up the listbox
                string[] TaskActions = Directory.GetFiles(TaskDirectory, "*.txt");


                foreach (string TaskAction in TaskActions)
                {
                    //variables for the add action arguments
                    string time = "";
                    string mode = "";
                    string theme = "";

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

                    

                    //add the action to the add dynamic theme task listbox
                    addDynamicThemeTask.AddAction(time, mode, theme);

                }


                //show the window
                addDynamicThemeTask.Owner = this;
                addDynamicThemeTask.Show();

                //disable this window
                this.IsEnabled = false;

                //move taskdir to the temp folder
                Directory.Move(TaskDirectory, System.IO.Path.Combine(DataDynamicThemeTempDir, 
                    new DirectoryInfo(TaskDirectory).Name));

                //assign the temp task dir to the variable in adddynamicthemetask window
                addDynamicThemeTask.TempTaskDir = System.IO.Path.Combine(DataDynamicThemeTempDir, 
                    new DirectoryInfo(TaskDirectory).Name);

            }
            else if (Directory.GetParent(TaskDirectory).Name == "DynamicWallpaper")
            {
                //The task is a dynamic theme task

                //init a new add dynamic wallpaper task window
                AddDynamicWallpaperTask addDynamicWallpaperTask = new AddDynamicWallpaperTask();

                //set edit mode to true
                addDynamicWallpaperTask.IsEditMode = true;

                //configure the window such that the name and actions (events) are already filled in
                addDynamicWallpaperTask.TaskNameTextBox.Text = new DirectoryInfo(TaskDirectory).Name;

                //iterate through text files in the directory, filling up the listbox
                string[] TaskActions = Directory.GetFiles(TaskDirectory, "*.txt");

                foreach (string TaskAction in TaskActions)
                {
                    //variables to store info from text file
                    string wallpaper = "";
                    string mode = "";
                    string trigger = "";

                    //read all lines in the text file
                    string[] lines = File.ReadAllLines(TaskAction);

                    foreach (string line in lines)
                    {
                        if (line.Contains("wallpaper;"))
                        {
                            //remove the stuff after the semicolon and assign it to the time variable
                            wallpaper = line.Substring(line.IndexOf(';') + 1);
                        }
                        else if (line.Contains("mode;"))
                        {
                            //remove the stuff after the semicolon and assign it to the mode variable
                            mode = line.Substring(line.IndexOf(';') + 1);
                        }
                        else if (line.Contains("trigger;"))
                        {
                            //remove the stuff after the semicolon and assign it to the theme variable
                            trigger = line.Substring(line.IndexOf(';') + 1);
                        }
                    }

                    /*check the mode, if the mode is "time", add a time event, otheriwse, 
                     * if the mode is "battery", add a battery event*/

                    if (mode == "time")
                    {
                        //Add a time action
                        addDynamicWallpaperTask.AddTimeEvent(trigger, wallpaper);
                    }
                    else if (mode == "battery")
                    {
                        //add a battery action (parse trigger as an int for the battery percentage)
                        addDynamicWallpaperTask.AddBatteryEvent(int.Parse(trigger), wallpaper);
                    }


                }

                //show the window
                addDynamicWallpaperTask.Owner = this;
                addDynamicWallpaperTask.Show();

                //disable this window
                this.IsEnabled = false;

                //move taskdir to the temp folder
                Directory.Move(TaskDirectory, System.IO.Path.Combine(DataDynamicWallpaperTempDir,
                    new DirectoryInfo(TaskDirectory).Name));

                //assign the temp task dir to the variable in adddynamicwallpapertask window
                addDynamicWallpaperTask.TempTaskDir = System.IO.Path.Combine(DataDynamicWallpaperTempDir,
                    new DirectoryInfo(TaskDirectory).Name);

            }
        }

        private void RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            //cast the sender as MenuItem
            MenuItem RemoveItem = sender as MenuItem;

            //get the context menu that the menu item belongs to
            ContextMenu MenuFlyout = RemoveItem.Parent as ContextMenu;

            //get the source control of the context menu
            Button MoreBtn = MenuFlyout.PlacementTarget as Button;

            //get the tag of the button (that's where the directory of the task is stored)
            string TaskDirectory = MoreBtn.Tag.ToString();

            //delete the task directory and all of its contents
            Directory.Delete(TaskDirectory, true);

            //update the listbox accordingly
            //check if the directory belongs to dynamic theme or dynamic wallpaper
            if (Directory.GetParent(TaskDirectory).Name == "DynamicTheme")
            {
                //The task is a dynamic theme task
                UpdateTaskListBox(DynamicThemeListBox, 0);
            }
            else if (Directory.GetParent(TaskDirectory).Name == "DynamicWallpaper")
            {
                //The task is a dynamic theme task
                UpdateTaskListBox(DynamicWallpaperListBox, 1);
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
                addDynamicThemeTask.Show();

                //disable this window
                this.IsEnabled = false;

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
                addDynamicWallpaperTask.Show();

                //disable this window
                this.IsEnabled = false;

                //deselect all items from the listbox
                DynamicWallpaperListBox.UnselectAll();
            }
        }
    }
}
