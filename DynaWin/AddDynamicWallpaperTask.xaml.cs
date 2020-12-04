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
            //This event handler is for adding a time event
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
