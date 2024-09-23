using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
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

        //The following three properties are used for the pick up time
        public DateTime SelectedPickUpTime { get; set; }
        public string CurrentPickUpTime { get; set; }
        public DateTime CombinedPickUpDateTime { get; set; }
        
        //The following three properties are used for the drop off time
        public DateTime SelectedDropOffTime { get; set; }
        public string CurrentDropOffTime { get; set; }
        public DateTime CombinedDropOffDateTime { get; set; }
        
        public string UpdateFromAddress { get; set; }
        public string UpdateToAddress { get; set; }

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
            UpdateDescription = CurrentAssignment.Description;
            UpdateFromAddress = CurrentAssignment.FromAddress;
            UpdateToAddress = CurrentAssignment.ToAddress;
        }

        //Help methods for time managing
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
        }

        //Methods for RelayCommands
        private void SaveUpdateAndCloseWindow(object parameter)
        {
            UpdateCombinedPickUpDateTime();

            CurrentAssignment.Description = UpdateDescription;
            CurrentAssignment.PickUpTime = CombinedPickUpDateTime;
            CurrentAssignment.DropOffTime = CombinedDropOffDateTime;
            CurrentAssignment.FromAddress = UpdateFromAddress;
            CurrentAssignment.ToAddress = UpdateToAddress;

            if (parameter is UpdateWindow updateWindow)
            {
                updateWindow.DialogResult = true;
                updateWindow.Close();
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
