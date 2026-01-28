using System.Windows.Input;

namespace WPF.Common.DelegateCommand;

public class DelegateCommand : ICommand
{

    #region Public Events

    //public event EventHandler? CanExecuteChanged
    //{
    //    add => CommandManager.RequerySuggested += value;
    //    remove => CommandManager.RequerySuggested -= value;
    //}

    public event EventHandler? CanExecuteChanged;

    #endregion

    #region Private Read Only Variables

    private readonly Action<object> _execute;

    private readonly Func<object, bool> _canExecute;

    #endregion

    #region Constructors

    //public DelegateCommand(Action<object> execute, Func<object, bool> canExecute)
    //{
    //    _execute = execute ?? throw new ArgumentNullException(nameof(execute));
    //    _canExecute = canExecute ?? throw new ArgumentNullException(nameof(canExecute));
    //}

    //public DelegateCommand(Action<object> execute) : this(execute, _ => true) { }

    //public DelegateCommand(Action execute, Func<bool> canExecute) : this(_ => execute(), _ => canExecute()) { }

    //public DelegateCommand(Action execute) : this(execute, () => true) { }

    public DelegateCommand(Action<object?> execute, Func<object?, bool> canExecute)
    {
        _execute = execute;
        _canExecute = canExecute;

        CommandManager.RequerySuggested += (_, _) => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    public DelegateCommand(Action<object?> execute)
        : this(execute, _ => true)
    {
    }

    #endregion

    #region Public Methods

    public bool CanExecute(object parameter) => _canExecute(parameter);

    public void Execute(object parameter) => _execute(parameter);

    #endregion

}