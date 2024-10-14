using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using RegionSyd_Team8.Models;
using RegionSyd_Team8.MVVM;
using RegionSyd_Team8.Views;

namespace RegionSyd_Team8.ViewModels
{
    public class UpdateViewModel : ViewModelBase
    {
        //This property binds to SelectedAssignment and keeps track of what is to be saved
        public Assignment CurrentAssignment { get; set; }

        public string UpdateDescription { get; set; }
        public string UpdateDescription2 { get; set; }

        //The following six properties are used for the pick up time
        public DateTime SelectedPickUpTime { get; set; }
        public string CurrentPickUpTime { get; set; }
        public DateTime CombinedPickUpDateTime { get; set; }

        public DateTime SelectedPickUpTime2 { get; set; }
        public string CurrentPickUpTime2 { get; set; }
        public DateTime CombinedPickUpDateTime2 { get; set; }

        //The following six properties are used for the drop off time
        public DateTime SelectedDropOffTime { get; set; }
        public string CurrentDropOffTime { get; set; }
        public DateTime CombinedDropOffDateTime { get; set; }

        public DateTime SelectedDropOffTime2 { get; set; }
        public string CurrentDropOffTime2 { get; set; }
        public DateTime CombinedDropOffDateTime2 { get; set; }

        public string UpdateFromAddress { get; set; }
        public string UpdateFromAddress2 { get; set; }
        public string UpdateToAddress { get; set; }
        public string UpdateToAddress2 { get; set; }

        //RelayCommands
        public RelayCommand SaveUpdate => new RelayCommand(execute => SaveUpdateAndCloseWindow(execute));
        public RelayCommand CancelUpdate => new RelayCommand(execute => CancelUpdateAndCloseWindow(execute));

        //Constructor
        public UpdateViewModel(Assignment selectedAssignment)
        {
            CurrentAssignment = selectedAssignment;

            SelectedPickUpTime = CurrentAssignment.PickUpTime;
            CurrentPickUpTime = TimeOnly.FromDateTime(selectedAssignment.PickUpTime).ToString();
            SelectedDropOffTime = CurrentAssignment.DropOffTime;
            CurrentDropOffTime = TimeOnly.FromDateTime(selectedAssignment.DropOffTime).ToString();

            SelectedPickUpTime2 = CurrentAssignment.PickUpTime2;
            CurrentPickUpTime2 = TimeOnly.FromDateTime(selectedAssignment.PickUpTime2).ToString();
            SelectedDropOffTime2 = CurrentAssignment.DropOffTime2;
            CurrentDropOffTime2 = TimeOnly.FromDateTime(selectedAssignment.DropOffTime2).ToString();

            UpdateDescription = CurrentAssignment.Description;
            UpdateDescription2 = CurrentAssignment.Description2;
            UpdateFromAddress = CurrentAssignment.FromAddress;
            UpdateFromAddress2 = CurrentAssignment.FromAddress2;
            UpdateToAddress = CurrentAssignment.ToAddress;
            UpdateToAddress2 = CurrentAssignment.ToAddress2;
        }

        //Help method for time managing
        private void UpdateCombinedPickUpDateTime()
        {
            if (TimeSpan.TryParse(CurrentPickUpTime, out TimeSpan time))
            {
                CombinedPickUpDateTime = SelectedPickUpTime.Date + time;
            }
            if (TimeSpan.TryParse(CurrentDropOffTime, out TimeSpan time2))
            {
                CombinedDropOffDateTime = SelectedDropOffTime.Date + time2;
            }

            if (TimeSpan.TryParse(CurrentPickUpTime2, out TimeSpan time3))
            {
                CombinedPickUpDateTime2 = SelectedPickUpTime2.Date + time3;
            }
            if (TimeSpan.TryParse(CurrentDropOffTime2, out TimeSpan time4))
            {
                CombinedDropOffDateTime2 = SelectedDropOffTime2.Date + time4;
            }
        }

        //Methods for RelayCommands
        private void SaveUpdateAndCloseWindow(object parameter)
        {

            UpdateCombinedPickUpDateTime();

            if (CombinedPickUpDateTime != default && CombinedDropOffDateTime != default)
            {
                CurrentAssignment.Description = UpdateDescription;
                CurrentAssignment.PickUpTime = CombinedPickUpDateTime;
                CurrentAssignment.DropOffTime = CombinedDropOffDateTime;
                CurrentAssignment.FromAddress = UpdateFromAddress;
                CurrentAssignment.ToAddress = UpdateToAddress;

                CurrentAssignment.Description2 = UpdateDescription2;
                CurrentAssignment.PickUpTime2 = CombinedPickUpDateTime2;
                CurrentAssignment.DropOffTime2 = CombinedDropOffDateTime2;
                CurrentAssignment.FromAddress2 = UpdateFromAddress2;
                CurrentAssignment.ToAddress2 = UpdateToAddress2;

                if (parameter is UpdateWindow updateWindow)
                {
                    updateWindow.DialogResult = true;
                    updateWindow.Close();
                }
            }
            else
            {
                MessageBox.Show("Indtast venligst gyldige afhentnings- og afleveringstider, før du tilføjer en opgave.",
                      "Ugyldige tider",
                      MessageBoxButton.OK,
                     MessageBoxImage.Warning);
            }
        }

        private void CancelUpdateAndCloseWindow(object parameter)
        {
            if (parameter is UpdateWindow updateWindow)
            {
                updateWindow.DialogResult = false;
                updateWindow.Close();
            }
        }
    }
}
