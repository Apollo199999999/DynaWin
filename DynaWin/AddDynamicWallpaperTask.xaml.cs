using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using static DynaWin.PublicVariables;

namespace DynaWin
{
    /// <summary>
    /// Interaction logic for AddDynamicWallpaperTask.xaml
    /// </summary>
    public partial class AddDynamicWallpaperTask : Window
    {
        //this variable denotes whether this window is in edit mode or not
        public bool IsEditMode = false;

        //this variable denotes the temp task directory, used for editing
        public string TempTaskDir = "";

        public AddDynamicWallpaperTask()
        {
            InitializeComponent();
        }

        public void AddTimeEvent(string SelectedTime, string wallpaperPath)
        {
            //create a grid
            Grid TimeEventGrid = new Grid();
            TimeEventGrid.Width = 480;
            TimeEventGrid.Height = 415;

            //add a Label that says "Time Event:"
            Label label1 = new Label();
            label1.Content = "Time Event:";
            label1.FontSize = 16;
            label1.FontWeight = FontWeights.Bold;
            label1.VerticalAlignment = VerticalAlignment.Top;
            label1.HorizontalAlignment = HorizontalAlignment.Left;

            //create a label that says "Trigger this event"
            Label label2 = new Label();
            label2.Content = "Trigger this event when the time is";
            label2.HorizontalAlignment = HorizontalAlignment.Left;
            label2.VerticalAlignment = VerticalAlignment.Top;
            label2.Margin = new Thickness(0, 35, 0, 0);

            //create a timepicker
            TimePicker timePicker = new TimePicker();
            timePicker.SetTimeAsString(SelectedTime);
            timePicker.HorizontalAlignment = HorizontalAlignment.Left;
            timePicker.VerticalAlignment = VerticalAlignment.Top;
            timePicker.Margin = new Thickness(220, 29, 0, 0);

            //create a label that says "When this event is triggered"
            Label label3 = new Label();
            label3.Content = "When this event is triggered:";
            label3.HorizontalAlignment = HorizontalAlignment.Left;
            label3.VerticalAlignment = VerticalAlignment.Top;
            label3.FontWeight = FontWeights.Bold;
            label3.Margin = new Thickness(0, 125, 0, 0);

            //create a label that says "Change Wallpaper to:"
            Label label4 = new Label();
            label4.Content = "Change wallpaper to:";
            label4.HorizontalAlignment = HorizontalAlignment.Left;
            label4.VerticalAlignment = VerticalAlignment.Top;
            label4.Margin = new Thickness(0, 155, 0, 0);

            //create an image control
            Image WallpaperImage = new Image();
            WallpaperImage.StretchDirection = StretchDirection.Both;
            WallpaperImage.Stretch = Stretch.Uniform;
            WallpaperImage.Height = 170;
            WallpaperImage.Width = 440;
            //try and set the source of the image control
            try { WallpaperImage.Source = new BitmapImage(new Uri(wallpaperPath)); }
            catch (Exception e)
            {
                //show an error message
                MessageBox.Show("An error occured while trying to add the event with the wallpaper: " + wallpaperPath + "\n" +
                    "with the exception: " + "\n" + e.Message + "\n" + "Check that the file exists and change the wallpaper under the 'Events' " +
                    "section when you are done. In the meantime, the default DynaWin wallpaper will replace it. " +
                    "(You must save changes to the task, otherwise this error will persist)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                //set the placeholder wallpaper as image source
                WallpaperImage.Source = new BitmapImage(new Uri(GetPlaceholderWallpaperPath()));
            }

            WallpaperImage.HorizontalAlignment = HorizontalAlignment.Center;
            WallpaperImage.VerticalAlignment = VerticalAlignment.Top;
            WallpaperImage.Margin = new Thickness(0, 185, 0, 0);

            //create a button that says "Pick Image"
            Button PickImageBtn = new Button();
            PickImageBtn.Click += PickImageBtn_Click;
            PickImageBtn.Content = "Pick Image";
            PickImageBtn.HorizontalAlignment = HorizontalAlignment.Center;
            PickImageBtn.VerticalAlignment = VerticalAlignment.Top;
            //store the image control in the tag so that we can access it later
            PickImageBtn.Tag = WallpaperImage;
            PickImageBtn.Margin = new Thickness(0, 375, 0, 0);

            //add the controls to grid
            TimeEventGrid.Children.Add(label1);
            TimeEventGrid.Children.Add(label2);
            TimeEventGrid.Children.Add(label3);
            TimeEventGrid.Children.Add(label4);
            TimeEventGrid.Children.Add(WallpaperImage);
            TimeEventGrid.Children.Add(PickImageBtn);
            TimeEventGrid.Children.Add(timePicker);

            //add the grid to the listbox
            ActionsListBox.Items.Add(TimeEventGrid);

            //make the timeeventgrid the selected item and scrool it into view
            ActionsListBox.SelectedItem = TimeEventGrid;
            ActionsListBox.ScrollIntoView(ActionsListBox.SelectedItem);
        }

       
        //function to add battery event
        public void AddBatteryEvent(int batteryPercentage, string wallpaperPath)
        {
            //create a grid
            Grid BatteryEventGrid = new Grid();
            BatteryEventGrid.Width = 480;
            BatteryEventGrid.Height = 415;

            //add a Label that says "Time Event:"
            Label label1 = new Label();
            label1.Content = "Battery Event:";
            label1.FontSize = 16;
            label1.FontWeight = FontWeights.Bold;
            label1.VerticalAlignment = VerticalAlignment.Top;
            label1.HorizontalAlignment = HorizontalAlignment.Left;

            //create a label that says "Trigger this event"
            Label label2 = new Label();
            label2.Content = "Trigger this event when the battery percentage is";
            label2.HorizontalAlignment = HorizontalAlignment.Left;
            label2.VerticalAlignment = VerticalAlignment.Top;
            label2.Margin = new Thickness(0, 35, 0, 0);

            //create a numberbox (from ModernWPF)
            ModernWpf.Controls.NumberBox BatteryPercentageNumberBox = new ModernWpf.Controls.NumberBox();
            BatteryPercentageNumberBox.AcceptsExpression = true;
            BatteryPercentageNumberBox.SpinButtonPlacementMode =
                ModernWpf.Controls.NumberBoxSpinButtonPlacementMode.Compact;
            BatteryPercentageNumberBox.Value = batteryPercentage;
            BatteryPercentageNumberBox.Maximum = 100;
            BatteryPercentageNumberBox.Minimum = 1;
            BatteryPercentageNumberBox.HorizontalAlignment = HorizontalAlignment.Left;
            BatteryPercentageNumberBox.VerticalAlignment = VerticalAlignment.Top;
            BatteryPercentageNumberBox.Margin = new Thickness(315, 29, 0, 0);
            BatteryPercentageNumberBox.Height = 32;
            BatteryPercentageNumberBox.Width = 100;

            //create a label that says "%"
            Label label5 = new Label();
            label5.Content = "%";
            label5.HorizontalAlignment = HorizontalAlignment.Left;
            label5.VerticalAlignment = VerticalAlignment.Top;
            label5.Margin = new Thickness(420, 35, 0, 0);

            //create a label that says "When this event is triggered"
            Label label3 = new Label();
            label3.Content = "When this event is triggered:";
            label3.HorizontalAlignment = HorizontalAlignment.Left;
            label3.VerticalAlignment = VerticalAlignment.Top;
            label3.FontWeight = FontWeights.Bold;
            label3.Margin = new Thickness(0, 125, 0, 0);

            //create a label that says "Change Wallpaper to:"
            Label label4 = new Label();
            label4.Content = "Change wallpaper to:";
            label4.HorizontalAlignment = HorizontalAlignment.Left;
            label4.VerticalAlignment = VerticalAlignment.Top;
            label4.Margin = new Thickness(0, 155, 0, 0);

            //create an image control
            Image WallpaperImage = new Image();
            WallpaperImage.StretchDirection = StretchDirection.Both;
            WallpaperImage.Stretch = Stretch.Uniform;
            WallpaperImage.Height = 170;
            WallpaperImage.Width = 440;
            //try and set the source of the image control
            try { WallpaperImage.Source = new BitmapImage(new Uri(wallpaperPath)); } 
            catch (Exception e)
            {
                //show an error message
                MessageBox.Show("An error occured while trying to add the event with the wallpaper: " + wallpaperPath + "\n" +
                    "with the exception: " + "\n" + e.Message + "\n" + "Check that the file exists and change the wallpaper under the 'Events' " +
                    "section when you are done. In the meantime, the default DynaWin wallpaper will replace it. " +
                    "(You must save changes to the task, otherwise this error will persist)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                //set the placeholder wallpaper as image source
                WallpaperImage.Source = new BitmapImage(new Uri(GetPlaceholderWallpaperPath()));
            }

            WallpaperImage.HorizontalAlignment = HorizontalAlignment.Center;
            WallpaperImage.VerticalAlignment = VerticalAlignment.Top;
            WallpaperImage.Margin = new Thickness(0, 185, 0, 0);

            //create a button that says "Pick Image"
            Button PickImageBtn = new Button();
            PickImageBtn.Click += PickImageBtn_Click;
            PickImageBtn.Content = "Pick Image";
            PickImageBtn.HorizontalAlignment = HorizontalAlignment.Center;
            PickImageBtn.VerticalAlignment = VerticalAlignment.Top;
            //store the image control in the tag so that we can access it later
            PickImageBtn.Tag = WallpaperImage;
            PickImageBtn.Margin = new Thickness(0, 375, 0, 0);

            //add the controls to grid
            BatteryEventGrid.Children.Add(label1);
            BatteryEventGrid.Children.Add(label2);
            BatteryEventGrid.Children.Add(label3);
            BatteryEventGrid.Children.Add(label4);
            BatteryEventGrid.Children.Add(label5);
            BatteryEventGrid.Children.Add(WallpaperImage);
            BatteryEventGrid.Children.Add(PickImageBtn);
            BatteryEventGrid.Children.Add(BatteryPercentageNumberBox);

            //add the grid to the listbox
            ActionsListBox.Items.Add(BatteryEventGrid);

            //make the batteryeventgrid the selected item and scroll it into view
            ActionsListBox.SelectedItem = BatteryEventGrid;
            ActionsListBox.ScrollIntoView(ActionsListBox.SelectedItem);
        }

        private void PickImageBtn_Click(object sender, RoutedEventArgs e)
        {
            //handle the event handler when the pickimage btn is clicked
            //cast the tag of the pickimage btn as an image control
            Button PickImageBtn = sender as Button;
            Image WallpaperImage = PickImageBtn.Tag as Image;

            //open a file dialog to pick the image
            OpenFileDialog WallpaperFileDialog = new OpenFileDialog();
            WallpaperFileDialog.Filter = "All Image files (*.jpg;*.jpeg;*.bmp;.png;)" +
                "|*.jpg;*.jpeg;*.bmp;*.png;";

            if (WallpaperFileDialog.ShowDialog() == true)
            {
                //set the wallpaperimage image as the filename of the open file dialog
                WallpaperImage.Source = new BitmapImage(new Uri(WallpaperFileDialog.FileName));
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //show a message box to ask if they want to exit without saving changes

            if (MessageBox.Show("Exit without saving?", "Exit?", 
                MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                /*check if edit mode is true, if it is, move the original task dir back to dynamic wallpaper root dir
                because changes were not saved*/

                if (IsEditMode == true)
                {
                    //move the directory back
                    Directory.Move(TempTaskDir, System.IO.Path.Combine(DataDynamicWallpaperRootDir,
                        new DirectoryInfo(TempTaskDir).Name));
                }

                //set the editmode to false
                IsEditMode = false;

                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(SettingsWindow))
                    {
                        var settingsWindow = window as SettingsWindow;

                        //reenable this window
                        settingsWindow.IsEnabled = true;

                        //call the update task function
                        settingsWindow.UpdateTaskListBox(settingsWindow.DynamicWallpaperListBox, 1);

                        //activate settings window
                        settingsWindow.Activate();

                    }
                }
            }
            else
            {
                //dont close the window
                e.Cancel = true;
            }
        }

        private void TaskNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //only allow normal characters to be inputted. Do not allow special characters.
            //remove all illegal characters from the textbox text
            TaskNameTextBox.Text = TaskNameTextBox.Text.Replace("/", "");
            TaskNameTextBox.Text = TaskNameTextBox.Text.Replace(@"\", "");
            TaskNameTextBox.Text = TaskNameTextBox.Text.Replace(":", "");
            TaskNameTextBox.Text = TaskNameTextBox.Text.Replace("*", "");
            TaskNameTextBox.Text = TaskNameTextBox.Text.Replace("?", "");
            TaskNameTextBox.Text = TaskNameTextBox.Text.Replace("\"", "");
            TaskNameTextBox.Text = TaskNameTextBox.Text.Replace("<", "");
            TaskNameTextBox.Text = TaskNameTextBox.Text.Replace(">", "");
            TaskNameTextBox.Text = TaskNameTextBox.Text.Replace("|", "");
            TaskNameTextBox.Text = TaskNameTextBox.Text.Replace(".", "");
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            //saving mechanism
            if (CheckifTaskNameExists(DataDynamicWallpaperRootDir, TaskNameTextBox.Text) == true)
            {
                /*another task of the same name exists. This task cannot be created unless the name is changed. 
                Show the user an error message.*/

                MessageBox.Show("Another Dynamic Wallpaper task of the same name already exists, " +
                    "hence, this task cannot be saved. You should try renaming this task before you try again.", "Error " +
                    "while saving task", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else if (CheckifTaskNameExists(DataDynamicWallpaperRootDir, TaskNameTextBox.Text) == false)
            {
                //only save data if the name field is entered
                if (string.IsNullOrEmpty(TaskNameTextBox.Text) == false && string.IsNullOrWhiteSpace(TaskNameTextBox.Text) == false)
                {
                    //remove leading and trailing spaces from textbox.text
                    TaskNameTextBox.Text = TaskNameTextBox.Text.Trim();

                    //create a folder in the datadynamicrootdir with the folder name being the task name
                    string TaskDir = System.IO.Path.Combine(DataDynamicWallpaperRootDir, TaskNameTextBox.Text);

                    Directory.CreateDirectory(TaskDir);

                    //WARNING: THE FOLLOWING SAVING DATA CODE IS NOT VERY EFFICIENT, BUT I DON'T HAVE ANY OTHER METHOD
                    //iterate through the items in actionslistbox, and save the data
                    int i = 1;

                    //iterate through grid in actionslistbox
                    foreach (Grid EventItemGrid in ActionsListBox.Items)
                    {
                        string dataTextPath = System.IO.Path.Combine(TaskDir, i.ToString() + ".txt");

                        //create a text file to store data
                        var DataText = File.Create(dataTextPath);
                        DataText.Close();

                        StreamWriter sw = new StreamWriter(dataTextPath);

                        //iterate through controls in Grid
                        foreach (var control in EventItemGrid.Children)
                        {
                            if (control is TimePicker)
                            {
                                //cast control as TimePicker
                                TimePicker timePicker = control as TimePicker;

                                //save the time
                                sw.WriteLine("mode;time");
                                sw.WriteLine("trigger;" + timePicker.GetSelectedTime());

                            }
                            else if (control is ModernWpf.Controls.NumberBox)
                            {
                                //cast control as NumberBox
                                ModernWpf.Controls.NumberBox numberBox 
                                    = control as ModernWpf.Controls.NumberBox;

                                //save the value of numberbox
                                sw.WriteLine("mode;battery");
                                sw.WriteLine("trigger;" + numberBox.Value.ToString());
                            }

                            else if (control is Image)
                            {
                                //cast control elemnt as Image
                                Image image = control as Image;

                                //get the filepath of the source of the image
                                string ImageSource = (image.Source as BitmapImage).UriSource.OriginalString;

                                //write to text file
                                sw.WriteLine("wallpaper;" + ImageSource);
                            }
                        }

                        //close the data text file
                        sw.Close();

                        i++;

                    }

                    //delete the temp taskdir if edit mode is true
                    if (IsEditMode == true)
                    {
                        //delete the temptaskdir
                        Directory.Delete(TempTaskDir, true);
                    }

                    //set the editmode to false
                    IsEditMode = false;

                    //close this window
                    this.Close();
                }
                else
                {
                    //the name field is empty
                    MessageBox.Show("Please enter a name for this Dynamic Wallpaper task and try again.",
                        "Error while creating task", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }

        }

        //function to get placeholder wallpaper path (so i dont have to repeat myself)
        public string GetPlaceholderWallpaperPath()
        {
            string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
            string PlaceHolderWallpaperPath =
             System.IO.Path.Combine(RunningPath, @"Resources\PlaceHolderWallpaper.jpg");

            return PlaceHolderWallpaperPath;
        }

        private void AddTimeActionBtn_Click(object sender, RoutedEventArgs e)
        {
            //Add Time event with the default placeholder wallpaper
            AddTimeEvent("8:00 AM", GetPlaceholderWallpaperPath());
        }

        private void AddBatteryActionBtn_Click(object sender, RoutedEventArgs e)
        {
            //this event handler is for adding a battery event
            AddBatteryEvent(50, GetPlaceholderWallpaperPath());
        }

        private void ActionsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //check if an item is selected in the actionslistbox
            if (ActionsListBox.SelectedItem != null)
            {
                //an item is selected

                /*check if the items count of the listbox 
                 * disable the remove action button if its less than 1. Also change the tooltip text*/

                if (ActionsListBox.Items.Count > 1)
                {
                    /*it is not the first item, change the tooltip text to "Remove an Event" and 
                    enable the remove action button*/
                    RemoveActionBtnToolTip.Content = "Remove an Event";
                    RemoveActionBtn.IsEnabled = true;

                }
                else if (ActionsListBox.Items.Count <= 1)
                {
                    /*the listbox items count is 1. Disable the remove action button and 
                    change the tooltip text to "You cannot remove the first event"*/
                    RemoveActionBtnToolTip.Content = "You cannot remove the first event";
                    RemoveActionBtn.IsEnabled = false;

                }

            }
            else
            {
                //disable the remove action button and with the tooltip text as "No event selected to remove"
                RemoveActionBtnToolTip.Content = "There is no selected event to remove";
                RemoveActionBtn.IsEnabled = false;
            }
        }

       
        private void ActionsListBox_Loaded(object sender, RoutedEventArgs e)
        {
            //this is the event handler for when the actions list box loads. Add events here by default

            //add an action in the listbox as the default first item only IF iseditmode is set to false
            if (IsEditMode == false)
            {
                //add a time event
                AddTimeEvent("8:00 AM", GetPlaceholderWallpaperPath());

                //add a battery event
                AddBatteryEvent(50, GetPlaceholderWallpaperPath());
            }
            else if (IsEditMode == true)
            {
                //change the window title and the label text
                this.Title = "Edit Dynamic Wallpaper task";
                TitleLabel.Content = "Edit Dynamic Wallpaper task";
            }

        }

        private void RemoveActionBtn_Click(object sender, RoutedEventArgs e)
        {
            //remove the selected item in the actionslistbox
            ActionsListBox.Items.Remove(ActionsListBox.SelectedItem);
        }
    }
}
