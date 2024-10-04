﻿using RegionSyd_Team8.Models;
using RegionSyd_Team8.MVVM;
using RegionSyd_Team8.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace RegionSyd_Team8.ViewModels
{
    public class AssignmentViewModel : ViewModelBase
    {
        //Observable Collections
        public ObservableCollection<Assignment> Assignments { get; set; }
        //SelectedAssignments keeps track of how many assignments are selected in the datagrid
        public ObservableCollection<Assignment> SelectedAssignments { get; set; }

        //ICollectionView for filtering
        private ICollectionView assignmentCcollectionView;

        public ICollectionView AssignmentCollectionView
        {
            get { return assignmentCcollectionView; }
            set
            {
                assignmentCcollectionView = value;
                OnPropertyChanged(nameof(AssignmentCollectionView));
            }
        }

        private string assignmentFilter = String.Empty;

        public string AssignmentFilter
        {
            get { return assignmentFilter; }
            set
            {
                assignmentFilter = value;
                OnPropertyChanged(nameof(AssignmentFilter));
                AssignmentCollectionView.Refresh();
            }
        }

        //DateTime for filtering
        private DateTime? filterDate;

        public DateTime? FilterDate
        {
            get { return filterDate; }
            set
            {
                filterDate = value;
                OnPropertyChanged(nameof(FilterDate));
                AssignmentCollectionView.Refresh();
            }
        }

        //RelayCommands
        public RelayCommand UpdateCommand => new RelayCommand(execute => OpenUpdateWindow(), canExecute => CanOpenUpdateWindow());
        public RelayCommand CombineCommand => new RelayCommand(execute => OpenCombinationWindow(), canExecute => CanOpenCombinationWindow());

        //Constructor
        public AssignmentViewModel()
        {
            //The Assignments are only for testing purposes            
            Assignments = new ObservableCollection<Assignment>();
            SelectedAssignments = new ObservableCollection<Assignment>();

            AssignmentCollectionView = CollectionViewSource.GetDefaultView(Assignments);
            AssignmentCollectionView.Filter = FilterAssignments;

            //FilterDate = DateTime.Now;
            FilterDate = null;

            for (int i = 0; i < 30; i++)
            {
                Assignments.Add(new Assignment("Hent patient 0 fra hospitalet", DateTime.Now, DateTime.Now, "Hospitalsvej 1", "Husvej 1", false, false));
            }
        }

        public Assignment SelectedAssignment { get; set; }

        //Bool for filtering
        private bool FilterAssignments(object obj)
        {
            if (obj is Assignment assignment)
            {
                if (FilterDate == null)
                {
                    return assignment.AssignmentID.ToString().Contains(AssignmentFilter, StringComparison.InvariantCultureIgnoreCase) ||
                    assignment.Description.Contains(AssignmentFilter, StringComparison.InvariantCultureIgnoreCase) ||
                    assignment.ToAddress.Contains(AssignmentFilter, StringComparison.InvariantCultureIgnoreCase) ||
                    assignment.FromAddress.Contains(AssignmentFilter, StringComparison.InvariantCultureIgnoreCase);
                }
                else
                {
                    return assignment.PickUpTime.Date == FilterDate ||
                    assignment.DropOffTime.Date == FilterDate;
                }
            }

            return false;
        }

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
            AssignmentCollectionView.Refresh();
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
