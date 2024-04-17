using DemoApplication.ViewModels;
using System.Globalization;

namespace DemoApplication.Views;

public partial class LoginView : ContentPage
{
    public LoginView()
    {
        BindingContext = IPlatformApplication.Current.Services.GetService<LoginViewModel>();
        InitializeComponent();
    }
}
