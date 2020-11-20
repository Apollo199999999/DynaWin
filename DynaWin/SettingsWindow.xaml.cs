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

            

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
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
    }
}
