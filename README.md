# WPFCommon

A lightweight utility library that simplifies **command handling and ViewModel patterns in WPF applications**, following MVVM principles.

`WPFCommon` provides:

* A base `ViewModelBase` with built‑in `INotifyPropertyChanged` support
* A reusable `DelegateCommand` implementation
* A `CommandViewModel` abstraction to easily bind commands, visibility, and enabled state to the UI

This package is designed to **reduce boilerplate code** and make WPF command usage more readable, consistent, and maintainable.

---

## ✨ Features

* ✅ `ViewModelBase` with automatic property change notification
* ✅ Centralized property storage using `Get<T>() / Set<T>()`
* ✅ `DelegateCommand` implementation with `CanExecute` support
* ✅ Automatic UI refresh via `CommandManager.RequerySuggested`
* ✅ `CommandViewModel` for binding commands, tooltips, visibility, and enabled state
* ✅ Fully compatible with **MVVM**

---

## 📦 Installation

Install from **NuGet**:

```bash
dotnet add package WPFCommon
```

Or via **NuGet Package Manager** in Visual Studio:

```
WPFCommon
```

---

## 🧱 Core Components

### 1️⃣ ViewModelBase

`ViewModelBase` is the foundation for all ViewModels.

```csharp
public class MyViewModel : ViewModelBase
{
    public string Title
    {
        get => Get<string>() ?? string.Empty;
        set => Set(value);
    }
}
```

✔ Implements `INotifyPropertyChanged`
✔ Automatically updates bindings
✔ Refreshes commands when properties change

---

### 2️⃣ DelegateCommand

A simple and reusable `ICommand` implementation.

```csharp
public DelegateCommand SaveCommand { get; }

public MyViewModel()
{
    SaveCommand = new DelegateCommand(_ => Save(), _ => CanSave());
}

private void Save() { /* logic */ }
private bool CanSave() => true;
```

✔ Supports `CanExecute`
✔ Automatically raises `CanExecuteChanged`

---

### 3️⃣ CommandViewModel

`CommandViewModel` encapsulates everything needed to represent a command in the UI.

```csharp
new CommandViewModel(
    "Save",
    new DelegateCommand(_ => Save()),
    "Save current data",
    Visibility.Visible,
    true
)
```

Properties included:

* `Command`
* `IsEnabled`
* `CommandVisibility`
* `DisplayName`
* `DisplayToolTip`

---

## 🚀 Example (from included WPF demo)

### ViewModel

```csharp
public class FirstTabViewModel : ViewModelBase
{
    public IEnumerable<CommandViewModel> Commands { get; }

    public FirstTabViewModel()
    {
        Commands = new List<CommandViewModel>
        {
            new CommandViewModel(
                "Only text and action",
                new DelegateCommand(_ => Click1())
            ),
            new CommandViewModel(
                "Text, tooltip and action",
                new DelegateCommand(_ => Click2()),
                "Tool Tip Button"
            ),
            new CommandViewModel(
                "Disabled Button",
                new DelegateCommand(_ => Click3()),
                "Disabled",
                null,
                false
            )
        };
    }

    private void Click1() => MessageBox.Show("Button 1 clicked");
    private void Click2() => MessageBox.Show("Button 2 clicked");
    private void Click3() { }
}
```

### XAML Binding

```xml
<Button
    Content="{Binding DisplayName}"
    Command="{Binding Command}"
    IsEnabled="{Binding IsEnabled}"
    Visibility="{Binding CommandVisibility}" />
```

This allows you to **dynamically control UI behavior** entirely from the ViewModel.

---

## 🧠 Why use WPFCommon?

* Avoid repetitive `INotifyPropertyChanged` code
* Centralize command logic
* Improve ViewModel readability
* Keep UI logic out of code‑behind

Ideal for:

* Small to medium WPF projects
* MVVM‑based applications
* Teams looking for consistency

---

## 📄 License

MIT License

---

## 👤 Author

**Carlos Adrián Cervantes Durán**
GitHub: [https://github.com/IngNefly](https://github.com/IngNefly)

---

## 🔧 Notes

* Target framework: **.NET 8.0 (Windows)**
* Requires WPF (`UseWPF=true`)
* Designed for extensibility

---

⭐ If you find this package useful, feel free to star the repository or contribute!
