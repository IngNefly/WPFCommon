using System.Windows;
using WPF.Common.BaseObjects;
using WPF.Common.DelegateCommand;

namespace WPF.Common.CommandViewModelObjects;

public sealed class CommandViewModel : ViewModelBase
{
    #region Constructors

    public CommandViewModel(string contentText, DelegateCommand.DelegateCommand command) : base(contentText)
    {
        Command = command;
        IsEnabled = true;
        CommandVisibility = Visibility.Visible;
    }

    public CommandViewModel(string contentText, DelegateCommand.DelegateCommand command, 
        string displayToolTip, Visibility? visibility = null, bool? isEnabled = null) 
        : base(contentText, displayToolTip)
    {
        Command = command;
        IsEnabled = isEnabled ?? true;
        CommandVisibility = visibility ?? Visibility.Visible;
    }

    #endregion

    #region Public Variables

    public DelegateCommand.DelegateCommand Command { get; }    

    public bool IsEnabled { get; set; }

    public Visibility CommandVisibility { get => Get<Visibility>(); set => Set(value); }
    
    #endregion
}