using DemoApplication.ViewModels;

namespace DemoApplication.Views
{
    public partial class ProfileView : ContentPage
    {
        ProfileViewModel _profileViewModel;
        public ProfileView()
        {
            _profileViewModel = IPlatformApplication.Current.Services.GetService<ProfileViewModel>();
            BindingContext = _profileViewModel;
            InitializeComponent();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.NewTextValue))
            {
                _profileViewModel.UserDetail.Data = _profileViewModel.UserDetail.Data.Where(i => i.FirstName != null &&
                i.FirstName.ToLower().Contains(e.NewTextValue.ToLower()) ||
                i.Last_name != null &&
                i.Last_name.ToLower().Contains(e.NewTextValue.ToLower()));
            }
        }
    }
}

