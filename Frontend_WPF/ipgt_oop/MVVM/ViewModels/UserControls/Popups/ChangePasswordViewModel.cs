using System.Windows;
using System.Windows.Input;
using ipgt_oop.Core;
using ipgt_oop.Services;

namespace ipgt_oop.MVVM.ViewModels.UserControls.Popups;

public class ChangePasswordViewModel : ObservableObject
{/*
    public ICommand ChangePasswordCommand { get; }
    public event EventHandler<string> RequestErrorPopup;
    public event EventHandler<string> RequestSuccessPopup;
    
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
    
    private string _newPassword;
    public string NewPassword
    {
        get => _newPassword;
        set => SetProperty(ref _newPassword, value);
    }

    public ChangePasswordViewModel()
    {
        ChangePasswordCommand = new RelayCommand(o => ChangePassword(), o => true);
    }

    public async void ChangePassword()
    {
        
        var api = new ApiService();
        bool changePasswordSuccess =  await api.ChangeClientPassword(Username, Password,  NewPassword);

        if (changePasswordSuccess)
        {
            RequestSuccessPopup?.Invoke(this, "Password changed successfully");
        }
        else
        {
            RequestErrorPopup?.Invoke(this, "Password change failed");
        }
    }*/

}