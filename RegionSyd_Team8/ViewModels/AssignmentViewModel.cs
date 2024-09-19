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
        public ObservableCollection<Assignment> Assignments { get; set; }

        public ObservableCollection<Assignment> SelectedAssignments { get; set; }

        public RelayCommand UpdateCommand => new RelayCommand(execute => OpenUpdateWindow(), canExecute => CanOpenUpdateWindow());

        public AssignmentViewModel() 
        { 
            //Assignments used for testing purposes
            
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
        }
        
        public Assignment SelectedAssignment { get; set; }

        private void OpenUpdateWindow()
        {
            var updateWindow = new UpdateWindow();
            updateWindow.Show();
        }

        private bool CanOpenUpdateWindow()
        {
            return SelectedAssignments.Count == 1;
        }
    }
}
