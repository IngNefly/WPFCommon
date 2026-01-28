using WPF.Common.BaseObjects;

namespace WpfUI.ViewModels;

public class MainViewModel : ViewModelBase
{

    #region Private Variables

    private const string _title = "Main Window";

    #endregion

    #region Constructors

    public MainViewModel() : base(_title) 
    {
        MainTitle = "Welcome to WPF Common!";

        Tabs = new ViewModelBase[]
        {
            new FirstTabViewModel(),
            new SecondTabViewModel()
        };

        SelectedTab = Tabs.First();
    }

    #endregion

    #region Public Properties

    public string MainTitle
    {
        get => Get<string>() ?? string.Empty;
        set => Set(value);
    }

    public ViewModelBase SelectedTab { get => Get<ViewModelBase>(); set => Set(value); }

    public IEnumerable<ViewModelBase> Tabs { get; }

    #endregion
}