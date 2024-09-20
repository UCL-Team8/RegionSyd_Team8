using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegionSyd_Team8.Models;
using RegionSyd_Team8.MVVM;
using RegionSyd_Team8.Views;

namespace RegionSyd_Team8.ViewModels
{
    public class UpdateViewModel : ViewModelBase
    {
        public Assignment CurrentAssignment { get; set; }

        public RelayCommand CloseUpdateWindow => new RelayCommand(execute => CloseWindow(execute));

        public UpdateViewModel(Assignment selectedAssignment)
        {
            CurrentAssignment = selectedAssignment;
        }

        public void CloseWindow(object parameter)
        {
            if (parameter is UpdateWindow updateWindow)
            {
                updateWindow.DialogResult = true;
                updateWindow.Close();
            }
        }
    }
}
