using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DemoApplication.Services;
using DemoApplication.Views;

namespace DemoApplication.ViewModels
{
    public partial class LoginViewModel : ViewModelBase
	{
        #region Private
        private readonly IDataService _dataService;
        #endregion

        #region Public
        [ObservableProperty]
        string userName;

        [ObservableProperty]
        string password;

        [ObservableProperty]
        bool isTermsChecked;

        [ObservableProperty]
        bool isUserEmailValid;

        #endregion
        #region Constructor
        public LoginViewModel(IDataService dataService)
		{
            _dataService = dataService;
        }
        #endregion

        #region Commands

        [RelayCommand]
        async Task Login()
        {
            LoginRequest request = new()
            {
                email = UserName,
                password = Password
            };
            var result = await _dataService.LoginAsync(request);
            if(result != null)
            {
                Preferences.Set("Token", result.Token.ToString());
                //await Shell.Current.GoToAsync(nameof(ProfileView));
                Application.Current.MainPage = new AppShell();
            }
        }
        #endregion
    }
}

