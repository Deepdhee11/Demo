using DemoApplication.ViewModels;

namespace DemoApplication.Views;

public partial class ProfileMenuView : ContentPage
{
	public ProfileMenuView()
	{
		BindingContext = IPlatformApplication.Current.Services.GetService<ProfileMenuViewModel>(); ;
		InitializeComponent();
	}
}
