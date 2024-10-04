using RegionSyd_Team8.Models;
using RegionSyd_Team8.MVVM;
using RegionSyd_Team8.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RegionSyd_Team8.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private string _password;
        private string _errorMessage;
        public UserRepository _userRepository { get; set; }
        private Visibility _errorVisibility;

        //RelayCommands
        public RelayCommand LoginCommand => new RelayCommand(execute => Login());

        //public ICommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            _userRepository = new UserRepository();
            
            ErrorVisibility = Visibility.Collapsed;
            //LoginCommand = new RelayCommand(param => Login());
        }

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        public Visibility ErrorVisibility
        {
            get { return _errorVisibility; }
            set
            {
                _errorVisibility = value;
                OnPropertyChanged();
            }
        }

        public void Login()
        {
            var user = _userRepository.FindUser(Username, Password);
            if (user != null)
            {
                //var mainWindow = new MainWindow();
                //mainWindow.Show();

                //MessageBox.Show("MainWindow should be visible now.");//Debug

                //Application.Current.Windows[0].DialogResult = true;
                //Application.Current.Windows[0]?.Close();

                foreach (Window window in Application.Current.Windows)
                {
                    if (window is LoginWindow)
                    {
                        window.DialogResult = true;
                        window.Close();
                        break;
                    }
                }
            }
            else
            {
                ErrorMessage = "Ugyldigt brugernavn eller adgangskode!";
                ErrorVisibility = Visibility.Visible;
            }
        }
    }
} 