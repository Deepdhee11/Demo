using DemoApplication.ViewModels;

namespace DemoApplication.Views;

public partial class DetailView : ContentPage
{
	public DetailView()
	{
		BindingContext = IPlatformApplication.Current.Services.GetService<DetailViewModel>(); 
		InitializeComponent();
	}
}
