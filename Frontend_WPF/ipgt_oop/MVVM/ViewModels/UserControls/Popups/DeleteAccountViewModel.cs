using System.Windows.Input;
using ipgt_oop.Core;
using ipgt_oop.MVVM.Views.UserControls.Popups;
using ipgt_oop.Services;

namespace ipgt_oop.MVVM.ViewModels.UserControls.Popups;

public class DeleteAccountViewModel : ObservableObject
{/*
    public ICommand DeleteAccountCommand { get; }
    public event EventHandler<string> RequestErrorPopup;
    public event EventHandler<string> RequestSuccessPopup;
    public event EventHandler RequestHomeWindow;

    private string _username;
    public string Username
    {
        get => _username;
        set {_username = value; OnPropertyChanged(); }
    }
    
    private string _password;
    public string Password
    {
        get => _password;
        set => SetProperty(ref _password, value);
    }
    
    private string _confPassword;
    public string ConfPassword
    {
        get => _confPassword;
        set => SetProperty(ref _confPassword, value);
    }
    
    
    public DeleteAccountViewModel()
    {
        DeleteAccountCommand = new RelayCommand(o => DeleteAccount(), o => true);
    }

    public async void DeleteAccount()
    {

        if (Password != ConfPassword)
        {
            RequestErrorPopup?.Invoke(this, "Passwords don't match");
            return;
        }
        
        var api = new ApiService();
        bool deleteSuccess = await api.DeleteAccount();

        if (deleteSuccess)
        { 
            RequestSuccessPopup?.Invoke(this, "Account deleted successfully");
            RequestHomeWindow?.Invoke(this, EventArgs.Empty);
            
        }
        else
        {
            RequestErrorPopup?.Invoke(this, "Account deletion failed");
        }
    }*/
}