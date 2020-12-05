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
using System.IO;
using static DynaWin.PublicVariables;

namespace DynaWin
{
    /// <summary>
    /// Interaction logic for AddDynamicThemeTask.xaml
    /// </summary>
    public partial class AddDynamicThemeTask : Window
    {
        //this variable denotes whether this window is in edit mode or not
        public bool IsEditMode = false;

        //this variable denotes the temp task directory, used for editing
        public string TempTaskDir = "";

        public AddDynamicThemeTask()
        {
            InitializeComponent();
        }

        //create a function to add action
        public void AddAction(string time, string mode, string theme)
        {
            //create a Grid
            Grid ActionItem = new Grid();
            ActionItem.Height = 150;
            ActionItem.Width = 560;

            //create a label that says "Dynamic Theme Event"
            Label label1 = new Label();
            label1.Content = "Dynamic Theme Event:";
            label1.FontWeight = FontWeights.Bold;
            label1.HorizontalAlignment = HorizontalAlignment.Left;
            label1.VerticalAlignment = VerticalAlignment.Top;

            //create a label that says "Trigger this event at:"
            Label label2 = new Label();
            label2.Content = "Trigger this event at:";
            label2.HorizontalAlignment = HorizontalAlignment.Left;
            label2.VerticalAlignment = VerticalAlignment.Top;
            label2.Margin = new Thickness(0, 31, 0, 0);

            //create a TimePicker and set the initial time
            TimePicker TriggerTimePicker = new TimePicker();
            TriggerTimePicker.Margin = new Thickness(140, 25, 0, 0);
            TriggerTimePicker.HorizontalAlignment = HorizontalAlignment.Left;
            TriggerTimePicker.VerticalAlignment = VerticalAlignment.Top;
            TriggerTimePicker.SetTimeAsString(time);

            //create a label that says "When this event is triggered:"
            Label label3 = new Label();
            label3.Content = "When this event is triggered:";
            label3.HorizontalAlignment = HorizontalAlignment.Left;
            label3.VerticalAlignment = VerticalAlignment.Top;
            label3.Margin = new Thickness(0, 70, 0, 0);
            label3.FontWeight = FontWeights.Bold;

            //create a label that says "Change the"
            Label label4 = new Label();
            label4.Content = "Change the";
            label4.HorizontalAlignment = HorizontalAlignment.Left;
            label4.VerticalAlignment = VerticalAlignment.Top;
            label4.Margin = new Thickness(0, 111, 0, 0);

            //create a combobox for picking the system or app theme
            ComboBox SystemOrAppThemePicker = new ComboBox();
            SystemOrAppThemePicker.HorizontalAlignment = HorizontalAlignment.Left;
            SystemOrAppThemePicker.Margin = new Thickness(86, 105, 0, 0);
            SystemOrAppThemePicker.VerticalAlignment = VerticalAlignment.Top;
            SystemOrAppThemePicker.Width = 203;
            SystemOrAppThemePicker.Height = 32;

            //add items to the combo box
            ComboBoxItem SystemThemeItem = new ComboBoxItem();
            ComboBoxItem AppsThemeItem = new ComboBoxItem();
            SystemThemeItem.Content = "Default Windows mode";
            AppsThemeItem.Content = "Default app mode";

            SystemOrAppThemePicker.Items.Add(SystemThemeItem);
            SystemOrAppThemePicker.Items.Add(AppsThemeItem);

            //set the default selected item
            if (mode == "windows")
            {
                SystemOrAppThemePicker.SelectedItem = SystemThemeItem;
            }
            else if (mode == "apps")
            {
                SystemOrAppThemePicker.SelectedItem = AppsThemeItem;
            }

            //create a label that says "to"
            Label label5 = new Label();
            label5.Content = "to";
            label5.HorizontalAlignment = HorizontalAlignment.Left;
            label5.VerticalAlignment = VerticalAlignment.Top;
            label5.Margin = new Thickness(302, 111, 0, 0);

            //create a combobox for picking light theme or dark theme
            ComboBox LightDarkThemePicker = new ComboBox();
            LightDarkThemePicker.HorizontalAlignment = HorizontalAlignment.Left;
            LightDarkThemePicker.Margin = new Thickness(338, 105, 0, 0);
            LightDarkThemePicker.VerticalAlignment = VerticalAlignment.Top;
            LightDarkThemePicker.Width = 136;
            LightDarkThemePicker.Height = 32;

            //add items to the combo box
            ComboBoxItem LightThemeItem = new ComboBoxItem();
            ComboBoxItem DarkThemeItem = new ComboBoxItem();
            LightThemeItem.Content = "Light Theme";
            DarkThemeItem.Content = "Dark Theme";

            LightDarkThemePicker.Items.Add(LightThemeItem);
            LightDarkThemePicker.Items.Add(DarkThemeItem);

            //set the default selected item
            if (theme == "light")
            {
                LightDarkThemePicker.SelectedItem = LightThemeItem;
            }
            else if (theme == "dark")
            {
                LightDarkThemePicker.SelectedItem = DarkThemeItem;
            }


            //add everything to the grid
            ActionItem.Children.Add(label1);
            ActionItem.Children.Add(label2);
            ActionItem.Children.Add(TriggerTimePicker);
            ActionItem.Children.Add(label3);
            ActionItem.Children.Add(label4);
            ActionItem.Children.Add(SystemOrAppThemePicker);
            ActionItem.Children.Add(label5);
            ActionItem.Children.Add(LightDarkThemePicker);

            //add the grid to the actionlistbox
            ActionsListBox.Items.Add(ActionItem);

            //make the action item the selected item and scroll to the selected item
            ActionsListBox.SelectedItem = ActionItem;
            ActionsListBox.ScrollIntoView(ActionsListBox.SelectedItem);
        }

        private void ActionsListBox_Loaded(object sender, RoutedEventArgs e)
        {
            //add an action in the listbox as the default first item only IF iseditmode is set to false
            if (IsEditMode == false)
            {
                AddAction("8:00 AM", "windows", "light");
            }
            else if (IsEditMode == true)
            {
                //change the window title and the label text
                this.Title = "Edit Dynamic Theme task";
                TitleLabel.Content = "Edit Dynamic Theme task";
            }
            
        }

        private void AddActionBtn_Click(object sender, RoutedEventArgs e)
        {
            //add an action
            AddAction("8:00 AM", "windows", "light");
        } 

        private void RemoveActionBtn_Click(object sender, RoutedEventArgs e)
        {
            //remove the selected item in the actionslistbox
            ActionsListBox.Items.Remove(ActionsListBox.SelectedItem);
        }

        private void ActionsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //check if an item is selected in the actionslistbox
            if (ActionsListBox.SelectedItem != null)
            {
                //an item is selected

                /*check if it is the first item. If it is the first item, 
                 * disable the remove action button. Also change the tooltip text*/

                if (ActionsListBox.SelectedIndex != 0)
                {
                    /*it is not the first item, change the tooltip text to "Remove an Event" and 
                    enable the remove action button*/
                    RemoveActionBtnToolTip.Content = "Remove an Event";
                    RemoveActionBtn.IsEnabled = true;

                }
                else if (ActionsListBox.SelectedIndex == 0)
                {
                    /*the selected item is the first item. Disable the remove action button and 
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


        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckifTaskNameExists(DataDynamicThemeRootDir, TaskNameTextBox.Text) == true)
            {
                /*another task of the same name exists. This task cannot be created unless the name is changed. 
                Show the user an error message.*/

                MessageBox.Show("Another Dynamic Theme task of the same name already exists, " +
                    "hence, this task cannot be saved. You should try renaming this task before you try again.", "Error " +
                    "while saving task", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (CheckifTaskNameExists(DataDynamicThemeRootDir, TaskNameTextBox.Text) == false)
            {
                //only save data if the name filed is entered
                if (string.IsNullOrEmpty(TaskNameTextBox.Text) == false && string.IsNullOrWhiteSpace(TaskNameTextBox.Text) == false)
                {
                    //remove leading and trailing spaces from textbox.text
                    TaskNameTextBox.Text = TaskNameTextBox.Text.Trim();

                    //create a folder in the datadynamicrootdir with the folder name being the task name
                    string TaskDir = System.IO.Path.Combine(DataDynamicThemeRootDir, TaskNameTextBox.Text);

                    Directory.CreateDirectory(TaskDir);

                    //WARNING: THE FOLLOWING SAVING DATA CODE IS NOT VERY EFFICIENT, BUT I DON'T HAVE ANY OTHER METHOD
                    //iterate through the items in actionslistbox, and save the data
                    int i = 1;

                    foreach (Grid ActionItem in ActionsListBox.Items)
                    {
                        string dataTextPath = System.IO.Path.Combine(TaskDir, i.ToString() + ".txt");

                        //create a text file to store data
                        var DataText = File.Create(dataTextPath);
                        DataText.Close();

                        StreamWriter sw = new StreamWriter(dataTextPath);

                        foreach (Control control in ActionItem.Children)
                        {
                            if (control is TimePicker)
                            {
                                TimePicker timePicker = control as TimePicker;
                                //save the time
                                sw.WriteLine("time;" + timePicker.GetSelectedTime());
                            }
                            else if (control is ComboBox)
                            {
                                ComboBox comboBox = control as ComboBox;

                                ComboBoxItem SelectedItem = comboBox.SelectedItem as ComboBoxItem;

                                //save combobox selected item
                                if (SelectedItem.Content.ToString() == "Light Theme")
                                {
                                    sw.WriteLine("theme;light");
                                }
                                else if (SelectedItem.Content.ToString() == "Dark Theme")
                                {
                                    sw.WriteLine("theme;dark");
                                }
                                else if (SelectedItem.Content.ToString() == "Default Windows mode")
                                {
                                    sw.WriteLine("mode;windows");
                                }
                                else if (SelectedItem.Content.ToString() == "Default app mode")
                                {
                                    sw.WriteLine("mode;apps");
                                }
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

                    this.Close();
                }
                else
                {
                    //the name field is empty
                    MessageBox.Show("Please enter a name for this Dynamic Theme task and try again.",
                        "Error while creating task", MessageBoxButton.OK, MessageBoxImage.Error);
                }


            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            /*check if edit mode is true, if it is, move the original task dir back to dynamic theme root dir
            because changes were not saved*/

            if (IsEditMode == true)
            {
                //move the directory back
                Directory.Move(TempTaskDir, System.IO.Path.Combine(DataDynamicThemeRootDir,
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
                    settingsWindow.UpdateTaskListBox(settingsWindow.DynamicThemeListBox, 0);

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
    }
}
