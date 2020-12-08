using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace DynaWin
{
    /// <summary>
    /// Interaction logic for AddDynamicWallpaperTask.xaml
    /// </summary>
    public partial class AddDynamicWallpaperTask : Window
    {
        public AddDynamicWallpaperTask()
        {
            InitializeComponent();
        }

        public void AddTimeEvent(string SelectedTime)
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
            label3.Margin = new Thickness(0, 75, 0, 0);

            //create a label that says "Change Wallpaper to:"
            Label label4 = new Label();
            label4.Content = "Change wallpaper to:";
            label4.HorizontalAlignment = HorizontalAlignment.Left;
            label4.VerticalAlignment = VerticalAlignment.Top;
            label4.Margin = new Thickness(0, 105, 0, 0);

            //create an image control
            Image WallpaperImage = new Image();
            WallpaperImage.StretchDirection = StretchDirection.Both;
            WallpaperImage.Stretch = Stretch.Uniform;
            WallpaperImage.Height = 230;
            WallpaperImage.Width = 440;
            WallpaperImage.HorizontalAlignment = HorizontalAlignment.Center;
            WallpaperImage.VerticalAlignment = VerticalAlignment.Top;
            WallpaperImage.Margin = new Thickness(0, 135, 0, 0);

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
        }

        private void PickImageBtn_Click(object sender, RoutedEventArgs e)
        {
            //handle the event handler when the pickimage btn is clicked
            //cast the tag of the pickimage btn as an image control
            Button PickImageBtn = sender as Button;
            Image WallpaperImage = PickImageBtn.Tag as Image;

            //open a file dialog to pick the image
            OpenFileDialog WallpaperFileDialog = new OpenFileDialog();
            WallpaperFileDialog.Filter = "All Image files (*.jpg;*.jpeg;*.bmp;*.dib;*.png;" +
                "*.jfif;*.jpe;*.gif;*.tif;*.tiff;*.wdp;*.heic;*.heif;*.heics;*.heifs;*.avci;*.avcs;*.avit*.avifs)" +
                "|*.jpg;*.jpeg;*.bmp;*.dib;*.png;*.jfif;*.jpe;*.gif;*.tif;*.tiff;*.wdp;*.heic;*.heif;*.heics;*.heifs;" +
                "*.avci;*.avcs;*.avit*.avifs";

            if (WallpaperFileDialog.ShowDialog() == true)
            {
                //set the wallpaperimage image as the filename of the open file dialog
                WallpaperImage.Source = new BitmapImage(new Uri(WallpaperFileDialog.FileName));
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
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
            //TODO: Add the saving mechanism here
        }

        private void AddTimeActionBtn_Click(object sender, RoutedEventArgs e)
        {
            //add a time event
            AddTimeEvent("8:00 AM");
        }

        private void AddThemeActionBtn_Click(object sender, RoutedEventArgs e)
        {
            //This event handler is for adding a theme event
        }

        private void AddBatteryActionBtn_Click(object sender, RoutedEventArgs e)
        {
            //this event handler is for adding a battery event
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
        }

        private void RemoveActionBtn_Click(object sender, RoutedEventArgs e)
        {
            //remove the selected item in the actionslistbox
            ActionsListBox.Items.Remove(ActionsListBox.SelectedItem);
        }
    }
}
