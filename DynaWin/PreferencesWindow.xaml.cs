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
using System.Diagnostics;
using System.Windows.Navigation;
using static DynaWin.PublicVariables;

namespace DynaWin
{
    /// <summary>
    /// Interaction logic for PreferencesWindow.xaml
    /// </summary>
    public partial class PreferencesWindow : Window
    {
        public PreferencesWindow()
        {
            InitializeComponent();

            //set the text of the VersionLabel to the current verion (from public variables)
            VersionLabel.Content = "Current version: " + DynaWinCurrentVersion;
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

                    //activate settings window
                    settingsWindow.Activate();

                }
            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HyperLink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            //navigate to the link
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
