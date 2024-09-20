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
        //SelectedAssignments holder styr på, hvor mange opgaver, som er valgt i ListBoxen
        public ObservableCollection<Assignment> SelectedAssignments { get; set; }

        //RelayCommands
        public RelayCommand UpdateCommand => new RelayCommand(execute => OpenUpdateWindow(), canExecute => CanOpenUpdateWindow());
        public RelayCommand CombineCommand => new RelayCommand(execute => OpenCombinationWindow(), canExecute => CanOpenCombinationWindow());

        //Constructor
        public AssignmentViewModel() 
        { 
            //Opgaverne her er kun til test            
            Assignments = new ObservableCollection<Assignment>();
            SelectedAssignments = new ObservableCollection<Assignment>();

            Assignments.Add(new Assignment
            {
                AssignmentID = 1,
                Description = "Hent patient 0 fra hospitalet",
                PickUpTime = DateTime.Now,
                DropOffTime = DateTime.Now,
                FromAddress = "Hospitalsvej 1",
                ToAddress = "Husvej 2"
            });
            Assignments.Add(new Assignment
            {
                AssignmentID = 2,
                Description = "Hent patient 1 fra hospitalet",
                PickUpTime = DateTime.Now,
                DropOffTime = DateTime.Now,
                FromAddress = "Hospitalsvej 2",
                ToAddress = "Husvej 3"
            });
            Assignments.Add(new Assignment
            {
                AssignmentID = 3,
                Description = "Hent patient 2 fra hospitalet",
                PickUpTime = DateTime.Now,
                DropOffTime = DateTime.Now,
                FromAddress = "Hospitalsvej 24",
                ToAddress = "Husvej 9"
            });
        }
        
        public Assignment SelectedAssignment { get; set; }

        //Metoder til RelayCommands
        private void OpenUpdateWindow()
        {
            UpdateViewModel updateViewModel = new UpdateViewModel(SelectedAssignment);
            UpdateWindow updateWindow = new UpdateWindow
            {
                DataContext = updateViewModel
            };
            
            //ShowDialog gør, at det underliggende vindue ikke kan tilgås, før man har lukket det nye vindue
            updateWindow.ShowDialog();
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
