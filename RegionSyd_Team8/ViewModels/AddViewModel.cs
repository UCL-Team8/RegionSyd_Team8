using RegionSyd_Team8.Models;
using RegionSyd_Team8.MVVM;
using RegionSyd_Team8.Views;

namespace RegionSyd_Team8.ViewModels
{
    class AddViewModel : ViewModelBase
    {
        public Assignment NewAssignment { get; set; }
        public string Description { get; set; }
        public DateTime PickUpTime { get; set; } = DateTime.Now;
        public DateTime DropOffTime { get; set; } = DateTime.Now;
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }

        public RelayCommand AddTaskCommand => new RelayCommand(execute => AddNewTaskCommand(execute));

        private void AddNewTaskCommand(object parameter)

        {
            NewAssignment = new Assignment(Description, PickUpTime, DropOffTime, FromAddress, ToAddress, false, false);

            if (parameter is AddWindow addWindow)
            {
                addWindow.DialogResult = true;
                addWindow.Close();
            }
        }




    }
}
