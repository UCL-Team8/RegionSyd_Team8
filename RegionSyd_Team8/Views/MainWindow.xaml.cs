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

namespace RegionSyd_Team8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AssignmentViewModel vm = new AssignmentViewModel();
            DataContext = vm;
        }

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
    }
}