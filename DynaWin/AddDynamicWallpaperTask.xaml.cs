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
    }
}
