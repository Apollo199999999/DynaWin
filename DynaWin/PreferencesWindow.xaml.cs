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
using System.Reflection;
using Microsoft.Win32;
using System.IO;
namespace DynaWin
{
    /// <summary>
    /// Interaction logic for PreferencesWindow.xaml
    /// </summary>
    public partial class PreferencesWindow : Window
    {
        //function to remove dynawin from startup
        public void RemoveAppFromStartUp()
        {
            //iterate through .bat files in the startup folder, to find the one that has the words "start" and "dynawin" in it
            foreach (string BatchFile in Directory.GetFiles(StarupFolder, "*.bat"))
            {
                string line = File.ReadLines(BatchFile).First(); // gets the first line from file.

                //check if the line contains the words "dynawin and "start"
                if (line.ToLower().Contains("dynawin") && line.ToLower().Contains("start"))
                {
                    //delete the batch file
                    File.Delete(BatchFile);
                }
            }
        }

        //function to add dynawin to startup
        public void InstallAppOnStartUp()
        {
            RemoveAppFromStartUp();

            //create a .bat file that starts dynawin. Place the bat file in the startup folder
            StreamWriter sw = new StreamWriter(System.IO.Path.Combine(StarupFolder, "StartDynaWin.bat"));
            sw.WriteLine("::This script's purpose is to start DynaWin. " +
                "Do not remove this comment as it is used for identification purposes.");
            sw.WriteLine("@echo off");
            sw.WriteLine("cd " + "\"" + System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\"");
            sw.WriteLine("start " + System.IO.Path.GetFileName(Assembly.GetExecutingAssembly().Location));
            sw.Close();

        }

        //function to check if dynawin is running on startup
        public bool IsDynaWinRunningOnStartup()
        {
            bool RunOnStartup = false;

            //iterate through .bat files in the startup folder, to find the one that has the words "start" and "dynawin" in it
            foreach (string BatchFile in Directory.GetFiles(StarupFolder, "*.bat"))
            {
                string line = File.ReadLines(BatchFile).First(); // gets the first line from file.

                //check if the line contains the words "dynawin and "start"
                if (line.ToLower().Contains("dynawin") && line.ToLower().Contains("start"))
                {
                    //set run on startup to true
                    RunOnStartup = true;
                }
            }

            return RunOnStartup;
        }

        public PreferencesWindow()
        {
            InitializeComponent();

            //set the text of the VersionLabel to the current verion (from public variables)
            VersionLabel.Content = "Current version: " + DynaWinCurrentVersion;

            //set the checkbox check state
            StartupCheckBox.IsChecked = IsDynaWinRunningOnStartup();
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
            //check for updates
            CheckForUpdates(true);
        }

        private void HyperLink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            //navigate to the link
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            //check the checkstate of the run on windows startup
            if (StartupCheckBox.IsChecked == true)
            {
                //add application to startup
                InstallAppOnStartUp();

            }
            else if (StartupCheckBox.IsChecked == false)
            {
                //remove application from startup
                RemoveAppFromStartUp();

            }

            this.Close();
        }
    }
}
