using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WPF.Common.BaseObjects;

public abstract class ViewModelBase : INotifyPropertyChanged
{

    #region Private Variables

    private readonly IDictionary<string, object> _data = new Dictionary<string, object>();

    #endregion

    #region Public Events

    public event PropertyChangedEventHandler? PropertyChanged;

    #endregion

    #region Constructors

    protected ViewModelBase() : this(string.Empty) { }

    protected ViewModelBase(string displayName) => DisplayName = displayName;

    protected ViewModelBase(string displayName, string displayToolTip) : this(displayName) => DisplayToolTip = displayToolTip;

    #endregion

    #region Public Variables

    public string DisplayName { get; }

    public string DisplayToolTip { get; }

    #endregion

    #region Private Methods

    private void NotifyPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        CommandManager.InvalidateRequerySuggested();
    }

    #endregion

    #region Protected Methods

    protected T? Get<T>([CallerMemberName] string propertyName = "") =>
        _data.ContainsKey(propertyName) ? (T)_data[propertyName] : default;

    protected void Set<T>(T value, [CallerMemberName] string propertyName = "")
    {
        _data[propertyName] = value;
        NotifyPropertyChanged(propertyName);
    }

    protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        PropertyChanged?.Invoke(this, e);
    }

    #endregion

}