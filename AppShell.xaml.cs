using DemoApplication.Resources.Strings;
using DemoApplication.Views;

namespace DemoApplication
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private async void Logout_Clicked(object sender, EventArgs e)
        {
            bool alert = await DisplayAlert(AppResources.Logout, AppResources.ConfirmLogout, 
                AppResources.Logout, AppResources.Cancel);
            if (alert)
            {
                Preferences.Clear();
                Application.Current.MainPage = new LoginView();
            }
        }
    }
}
