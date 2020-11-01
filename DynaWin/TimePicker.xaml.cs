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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DynaWin
{
    /// <summary>
    /// Interaction logic for TimePicker.xaml
    /// </summary>
    public partial class TimePicker : UserControl
    {
        public int TimeHour = 1;
        public int TimeMinute = 0;
        public TimePicker()
        {
            InitializeComponent();

            //add the time items for hours
            while (TimeHour != 13)
            {
                string TimeHourItem = TimeHour.ToString();

                //add it to the Hours combobox
                Hours.Items.Add(TimeHourItem);

                TimeHour += 1;
            }

            //add the time items for minutes in intervals of 5
            while (TimeMinute != 60)
            {
                string TimeMinuteItem;

                if (TimeMinute <= 9)
                {
                    //this is a one digit number
                    TimeMinuteItem = "0" + TimeMinute.ToString();
                }
                else
                {
                    //this is a 2 digit number, don't need to add a leading zero
                    TimeMinuteItem = TimeMinute.ToString();
                }

                Minutes.Items.Add(TimeMinuteItem);

                TimeMinute += 5;
            }

            //add the AM and PM
            AMPM.Items.Add("AM");
            AMPM.Items.Add("PM");
        }

        //the code in this section is for the event handler-----------------------------------

        //Create an event handler
        public delegate void TimeSelectionChanged(object sender, SelectionChangedEventArgs e);
        public event TimeSelectionChanged OnTimeSelectionChanged;

        protected virtual void TimeSelectedChangeRaise(SelectionChangedEventArgs e)
        {
            // Raise the event
            if (OnTimeSelectionChanged != null)
                OnTimeSelectionChanged(this, e);
        }

        private void Hours_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //raise the selectionchanged event
            TimeSelectedChangeRaise(null);
        }

        private void Minutes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //raise the selectionchanged event
            TimeSelectedChangeRaise(null);
        }

        private void AMPM_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //raise the selectionchanged event
            TimeSelectedChangeRaise(null);
        }

        //------------------------------------------------------------------------------------

        //function to get the selected time
        public string GetSelectedTime()
        {
            //convert the selection from the comboboxes to string
            string SelectedTime = Hours.SelectedItem + ":" +
                Minutes.SelectedItem + " " + AMPM.SelectedItem;

            return SelectedTime;

        }

        //function to set the time
        //ONLY SET THE TIME IN MULTIPLES OF 5
        public void SetSelectedTime(int hour, int minute, string AMORPM)
        {
            //set the selected item
            Hours.SelectedItem = hour.ToString();
            Minutes.SelectedItem = minute.ToString();
            AMPM.SelectedItem = AMORPM.ToString();
        }

       //function to set the time using a string (e.g 8:00 AM, 12:00 PM)
       public void SetTimeAsString(string time)
        {
            //replace " " and ":" from the string with another character to split the string
            time = time.Replace(" ", ";");
            time = time.Replace(":", ";");

            //split the string using the ";"
            string[] splitTime = time.Split(';');

            //set the selecteditem of the comboboxes
            Hours.SelectedItem = splitTime[0];
            Minutes.SelectedItem = splitTime[1];
            AMPM.SelectedItem = splitTime[2];

            
        }
    }


}

