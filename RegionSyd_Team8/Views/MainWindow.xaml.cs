using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RegionSyd_Team8.Models;
using RegionSyd_Team8.ViewModels;
using RegionSyd_Team8.Views;
using Microsoft.Extensions.Configuration; 
using System.Data.SqlClient; 

namespace RegionSyd_Team8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public AssignmentRepository assignmentRepository;
        public MainWindow()
        {
            InitializeComponent();
            AssignmentViewModel vm = new AssignmentViewModel();
            DataContext = vm;

        }


        //Event which is triggered every time assignments are selected in the data grid
        private void AssignmentBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var viewModel = DataContext as AssignmentViewModel;
            if (viewModel != null)
            {
                viewModel.SelectedAssignments.Clear();
                foreach (var assignment in assignmentBox.SelectedItems)
                {
                    viewModel.SelectedAssignments.Add(assignment as Assignment);
                }
            }
        }

        ////Event which is triggered when loading rows
        //private void AssignmentBox_LoadingRow(object sender, DataGridRowEventArgs e)
        //{
        //    var item = e.Row.Item as Assignment;
        //    if (item != null && item.Combined)
        //    {
        //        e.Row.Background = new SolidColorBrush(Colors.LightGreen);
        //    }
        //}
    }
}