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
        public ObservableCollection<Assignment> Combinations;
        
        public Assignment Assignment1 { get; set; }
        public Assignment Assignment2 { get; set; }
        
        //RelayCommands
        public RelayCommand CombineCommand => new RelayCommand(execute => Combine(execute));

        public CombinationViewModel(ObservableCollection<Assignment> selectedAssignments) 
        {
            Combinations = new ObservableCollection<Assignment>();
            Combinations = selectedAssignments;
            Assignment1 = new Assignment();
            Assignment2 = new Assignment();
            Assignment1 = Combinations[0];
            Assignment2 = Combinations[1];
        }
        
        private void Combine(object parameter)
        {
            Assignment CombinedAssignment = new Assignment();
            CombinedAssignment.Description = Assignment1.Description;
            CombinedAssignment.Description2 = Assignment2.Description;
            CombinedAssignment.Combined = true;

            if (parameter is CombinationWindow combinationWindow)
            {
                combinationWindow.DialogResult = true;
                combinationWindow.Close();
            }
        }
    }
}
