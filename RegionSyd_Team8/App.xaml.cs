using System.Configuration;
using System.Data;
using System.Windows;

namespace RegionSyd_Team8
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //Added
            Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            var loginWindow = new Views.LoginWindow();
            bool? dialogResult = loginWindow.ShowDialog();

            if (dialogResult == true)
            {
                var mainWindow = new MainWindow();
                mainWindow.Show();

                //Added
                Application.Current.MainWindow = mainWindow;

                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            }
            else
            {
                //Shutdown();

                //Added
                Application.Current.Shutdown();
            }
        }

    }

}

