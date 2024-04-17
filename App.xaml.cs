using DemoApplication.Views;
using System.Globalization;

namespace DemoApplication
{
    public partial class App : Application
    {
        public App()
        {
            try
            {
                InitializeComponent();
                SetUICulture();
                if (this.MainPage == null)
                {
                    MainPage = new LoginView();
                }
            }
            catch(Exception exception) 
            {
                Console.WriteLine(exception.Message);
            }
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            // Workaround for: 'Either set MainPage or override CreateWindow.'??
            if (this.MainPage == null)
            {
                this.MainPage = new LoginView();
            }

            return base.CreateWindow(activationState);
        }

        private void SetUICulture()
        {
            Application.Current.UserAppTheme = AppTheme.Light;
            //CultureInfo appCulture = new CultureInfo("en-US");
            CultureInfo appCulture = new CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = appCulture;
            Thread.CurrentThread.CurrentUICulture = appCulture;

        }
    }
}
