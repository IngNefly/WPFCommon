using System.Configuration;
using System.Data;
using System.Windows;

namespace WpfUI;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{

    #region Private Variables

    private const string AppName = "WPF.Common";
    private readonly bool _createdNew = false;
    private readonly Mutex _mutex;

    #endregion

    public App()
    {
        //Register any external components here, e.g., DevExpress, Telerik, etc.

        _mutex = new Mutex(true, AppName, out _createdNew);

        if (!_createdNew)
        {
            MessageBox.Show("Another instance of the application is already running.", "Instance Already Running", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            Application.Current.Shutdown(0);
        }
    }

}
