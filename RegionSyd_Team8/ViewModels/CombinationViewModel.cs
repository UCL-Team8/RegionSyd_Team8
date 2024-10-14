using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegionSyd_Team8.Models;
using RegionSyd_Team8.MVVM;
using RegionSyd_Team8.Views;

namespace RegionSyd_Team8.ViewModels
{
    internal class CombinationViewModel : ViewModelBase
    {
        public ObservableCollection<Assignment> Combinations { get; set; }

        public Assignment CombinedAssignment { get; set; }
        public Assignment Assignment1 { get; set; }
        public Assignment Assignment2 { get; set; }

        //RelayCommands
        public RelayCommand CombineCommand => new RelayCommand(execute => Combine(execute));
        public RelayCommand CancelCombinationCommand => new RelayCommand(execute => CancelCombinationAndCloseWindow(execute));
        public RelayCommand SwitchCommand => new RelayCommand(execute => SwitchOrder());

        public CombinationViewModel(ObservableCollection<Assignment> selectedAssignments)
        {
            Combinations = new ObservableCollection<Assignment>();
            Combinations = selectedAssignments;
            //Assignment1 = new Assignment();
            //Assignment2 = new Assignment();
            Assignment1 = Combinations[0];
            Assignment2 = Combinations[1];
        }

        private void Combine(object parameter)
        {
            //Assignment NewAssignment = new Assignment
            //{
            //    Description = Assignment1.Description,
            //    Description2 = Assignment2.Description,
            //    PickUpTime = Assignment1.PickUpTime,
            //    PickUpTime2 = Assignment2.PickUpTime,
            //    DropOffTime = Assignment1.DropOffTime,
            //    DropOffTime2 = Assignment2.DropOffTime,
            //    FromAddress = Assignment1.FromAddress,
            //    FromAddress2 = Assignment1.FromAddress2,
            //    ToAddress = Assignment1.ToAddress,
            //    ToAddress2 = Assignment1.ToAddress2,               
            //    Combined = true
            //};

            Assignment NewAssignment = new Assignment(Assignment1.Description, Assignment2.Description, Assignment1.PickUpTime, Assignment2.PickUpTime, Assignment1.DropOffTime, Assignment2.DropOffTime, Assignment1.FromAddress, Assignment2.FromAddress, Assignment1.ToAddress, Assignment2.ToAddress, true);

            CombinedAssignment = NewAssignment;

            if (parameter is CombinationWindow combinationWindow)
            {
                combinationWindow.DialogResult = true;
                combinationWindow.Close();
            }
        }

        private void CancelCombinationAndCloseWindow(object parameter)
        {
            if (parameter is CombinationWindow combinationWindow)
            {
                combinationWindow.DialogResult = false;
                combinationWindow.Close();
            }
        }

        private void SwitchOrder()
        {
            if (Combinations.Count == 2)
            {
                Assignment temp = Assignment1;
                Assignment1 = Assignment2;
                Assignment2 = temp;

                OnPropertyChanged(nameof(Assignment1));
                OnPropertyChanged(nameof(Assignment2));
            }
        }
    }
}
