using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using WPF.Common.BaseObjects;
using WPF.Common.CommandViewModelObjects;
using WPF.Common.DelegateCommand;
using static System.Net.Mime.MediaTypeNames;

namespace WpfUI.ViewModels;

public class FirstTabViewModel : ViewModelBase
{

    #region Private Variables

    private const string _title = "First Tab";

    #endregion

    #region Constructors

    public FirstTabViewModel() : base(_title)
    {
        Commands = new List<CommandViewModel>
        {
            new CommandViewModel("Only text and action", new DelegateCommand(_ => Click1())),
            new CommandViewModel("Text, tool tip, action", new DelegateCommand(_ => Click2()), "Tool Tip Button 2"),
            new CommandViewModel("Disable Button", new DelegateCommand(_ => Click4()), "Enable", null, false),
            new CommandViewModel("Show hide button", new DelegateCommand(_ => Click3()), "Show Button"),
            new CommandViewModel("Hide me", new DelegateCommand(_ => Click4()), "Hide me", Visibility.Collapsed),            
        };
    }

    #endregion

    #region Public Properties

    public IEnumerable<CommandViewModel> Commands { get; private set; }

    #endregion

    #region Private Methods

    private void Click1()
    {
        MessageBox.Show("Clicked Button 1", "Information", MessageBoxButton.OK);
    }

    private void Click2() => MessageBox.Show("Clickec button 2", "Information", MessageBoxButton.OKCancel);

    private void Click3()
    {
        var button = Commands.FirstOrDefault(b => b.CommandVisibility == Visibility.Collapsed);
        button?.CommandVisibility = Visibility.Visible;
    }

    private void Click4()
    {
        var button = Commands.ElementAt(4);
        button.CommandVisibility = Visibility.Collapsed;
    }

    #endregion

}
