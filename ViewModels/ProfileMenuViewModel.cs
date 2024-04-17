using CommunityToolkit.Mvvm.ComponentModel;
using DemoApplication.Mapper;
using DemoApplication.Model;
using DemoApplication.Services;
using System;
namespace DemoApplication.ViewModels
{
	public  partial class ProfileMenuViewModel : ViewModelBase
	{
        private IDataService _dataService;

        [ObservableProperty]
        private User profileData;
        public ProfileMenuViewModel(IDataService dataService)
		{
            _dataService = dataService;
            Initialise();
		}

        private async Task Initialise()
        {
            var menu = await _dataService.GetProfile();
            ProfileData = BackendToAppModelMapper.GetProfile(menu.Data);
        }
    }
}

