using RegionSyd_Team8.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RegionSyd_Team8.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            var viewModel = new LoginViewModel();
            viewModel.Username = "admin"; // Manually set the Username
            //viewModel.Username = "user1";
            DataContext = viewModel;
        }

        // Login button click event handler
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Call the login method when the login button is clicked
            Login();
        }


        // Login logic
        private void Login()
        {
            var viewModel = DataContext as LoginViewModel;

            if (viewModel != null)
            {
                var user = viewModel._userRepository.FindUser(viewModel.Username, viewModel.Password);

                if (user != null)
                {
                    MessageBox.Show("Login lykkedes!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                    var mainWindow = new MainWindow();
                    mainWindow.Show();
                    Application.Current.Windows[0]?.Close();
                }
                else
                {
                    viewModel.ErrorMessage = "Ugyldigt brugernavn eller adgangskode!";
                    viewModel.ErrorVisibility = Visibility.Visible;
                }
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel viewModel)
            {
                viewModel.Password = (sender as PasswordBox)?.Password;
            }
        }
    }
}