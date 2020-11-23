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
    /// Interaction logic for AddDynamicThemeTask.xaml
    /// </summary>
    public partial class AddDynamicThemeTask : Window
    {
        public AddDynamicThemeTask()
        {
            InitializeComponent();
            DefaultTriggerTimePicker.SetTimeAsString("8:00 AM");
        }

        //create a function to add action
        public void AddAction()
        {
            //create a Grid
            Grid ActionItem = new Grid();
            ActionItem.Height = 150;
            ActionItem.Width = 560;

            //create a label that says "Dynamic Theme Action"
            Label label1 = new Label();
            label1.Content = "Dynamic Theme Action:";
            label1.FontWeight = FontWeights.Bold;
            label1.HorizontalAlignment = HorizontalAlignment.Left;
            label1.VerticalAlignment = VerticalAlignment.Top;

            //create a label that says "Trigger this action at:"
            Label label2 = new Label();
            label2.Content = "Trigger this action at:";
            label2.HorizontalAlignment = HorizontalAlignment.Left;
            label2.VerticalAlignment = VerticalAlignment.Top;
            label2.Margin = new Thickness(0, 31, 0, 0);

            //create a TimePicker and set the initial time
            TimePicker TriggerTimePicker = new TimePicker();
            TriggerTimePicker.Margin = new Thickness(140, 25, 0, 0);
            TriggerTimePicker.HorizontalAlignment = HorizontalAlignment.Left;
            TriggerTimePicker.VerticalAlignment = VerticalAlignment.Top;
            TriggerTimePicker.SetTimeAsString("8:00 AM");

            //create a label that says "When this action is triggered:"
            Label label3 = new Label();
            label3.Content = "When this action is triggered:";
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
            SystemThemeItem.Content = "Default Windows Mode";
            AppsThemeItem.Content = "Default app mode";

            SystemOrAppThemePicker.Items.Add(SystemThemeItem);
            SystemOrAppThemePicker.Items.Add(AppsThemeItem);

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
        }

        private void AddActionBtn_Click(object sender, RoutedEventArgs e)
        {
            AddAction();
        }
    }
}
