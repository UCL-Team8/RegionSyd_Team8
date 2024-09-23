using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RegionSyd_Team8.Models;
using RegionSyd_Team8.MVVM;
using RegionSyd_Team8.Views;

namespace RegionSyd_Team8.ViewModels
{
    public class AssignmentViewModel : ViewModelBase
    {
        //Observable Collections
        public ObservableCollection<Assignment> Assignments { get; set; }
        //SelectedAssignments keeps track of how many assignments are selected in the datagrid
        public ObservableCollection<Assignment> SelectedAssignments { get; set; }

        //DateTime for filtering
        public DateTime FilterDate { get; set; }

        //RelayCommands
        public RelayCommand UpdateCommand => new RelayCommand(execute => OpenUpdateWindow(), canExecute => CanOpenUpdateWindow());
        public RelayCommand CombineCommand => new RelayCommand(execute => OpenCombinationWindow(), canExecute => CanOpenCombinationWindow());

        //Constructor
        public AssignmentViewModel() 
        { 
            //The Assignments are only for testing purposes            
            Assignments = new ObservableCollection<Assignment>();
            SelectedAssignments = new ObservableCollection<Assignment>();

            FilterDate = DateTime.Now;

            for (int i = 0; i < 30; i++)
            {
                Assignments.Add(new Assignment("Hent patient 0 fra hospitalet", DateTime.Now, DateTime.Now, "Hospitalsvej 1", "Husvej 1"));
            }            
        }
        
        public Assignment SelectedAssignment { get; set; }

        //Methods for RelayCommands
        private void OpenUpdateWindow()
        {
            UpdateViewModel updateViewModel = new UpdateViewModel(SelectedAssignment);
            UpdateWindow updateWindow = new UpdateWindow
            {
                DataContext = updateViewModel
            };

            //ShowDialog only allows the user to interact with the current window
            updateWindow.ShowDialog();

            //Adds a new list to Assignments as the list wouldn't update otherwise
            Assignments = new ObservableCollection<Assignment>(Assignments);
            OnPropertyChanged(nameof(Assignments));
        }

        private bool CanOpenUpdateWindow()
        {
            return SelectedAssignments.Count == 1;
        }

        private void OpenCombinationWindow()
        {
            CombinationWindow combinationWindow = new CombinationWindow();
            combinationWindow.ShowDialog();
        }

        private bool CanOpenCombinationWindow()
        {
            return SelectedAssignments.Count == 2;
        }
    }
}
