using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using WPF.Common.BaseObjects;
using WPF.Common.CommandViewModelObjects;
using WPF.Common.DelegateCommand;

namespace WpfUI.ViewModels;

public class SecondTabViewModel : ViewModelBase
{

	#region Private Variables

	private const string _title = "Second Tab Title";

	#endregion

	#region Constructor

	public SecondTabViewModel() : base(_title)
	{

		Button1 = new CommandViewModel("Click me", new DelegateCommand(_ => ClickButton1()), "Click me");
		CheckCommand = new CommandViewModel("Check", new DelegateCommand(_ => CheckBoxComand()));
    }

	#endregion

	#region Public Properties

	public bool CheckBoxValue { get => Get<bool>(); set => Set(value); }

	#endregion

	#region Public Commands

	public CommandViewModel Button1 { get; set; }

	public CommandViewModel CheckCommand { get; }

	#endregion

	#region Private Methods

	private void ClickButton1()
	{
        MessageBox.Show("Clicked Button 1", "Information", MessageBoxButton.OK);
    }

	private void CheckBoxComand()
	{
		Button1.IsEnabled = !CheckBoxValue;
    }

    #endregion

}
