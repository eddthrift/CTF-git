using System.Windows;
using CTFSimulation.Views;

namespace CTFSimulation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow wnd = new MainWindow();
            wnd.Title = "CTF";
            wnd.Show();
        }
    }
}
