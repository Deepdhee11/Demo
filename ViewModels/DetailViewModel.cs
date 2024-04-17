using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DemoApplication.Model;
using DemoApplication.Resources.Strings;
using Kotlin.Properties;
using Newtonsoft.Json;

namespace DemoApplication.ViewModels
{
    [QueryProperty(nameof(UserDetail), "UserDetail")]
    public partial class DetailViewModel : ViewModelBase, IQueryAttributable
	{
        #region Property
        [ObservableProperty]
        private User userDetail;
        #endregion
        #region Constructor
        public DetailViewModel()
		{
		}
        #endregion
        #region Commands
        [RelayCommand]
        async Task Update()
        {
            var updateddetail = JsonConvert.SerializeObject(UserDetail);
            await Shell.Current.GoToAsync($"..?userdetail={updateddetail}");
        }

        [RelayCommand]
        public async Task EditProfile()
        {
            bool alert = await Application.Current.MainPage.DisplayAlert(AppResources.EditProfile,
                AppResources.Take_Pick_Photo, AppResources.TakePhoto, AppResources.PickPhoto);
            if (alert)
            {
                await TakePhoto();
            }
            else
            {
                await PickPhoto();
            }
        }
        #endregion
        #region Methods
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            UserDetail =(User) query["UserDetail"];
            OnPropertyChanged("UserDetail");
        }
        private async Task TakePhoto()
        {
            try
            {
                await Permissions.RequestAsync<Permissions.Camera>();
                await Permissions.RequestAsync<Permissions.StorageWrite>();
                var status = await Permissions.CheckStatusAsync<Permissions.Camera>();
                var StorageStatus = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();
                if (DeviceInfo.Platform == DevicePlatform.Android && int.Parse(DeviceInfo.VersionString) >= 13)
                {
                    StorageStatus = PermissionStatus.Granted;
                }
                if (StorageStatus == PermissionStatus.Granted && status == PermissionStatus.Granted)
                {
                    if (MediaPicker.Default.IsCaptureSupported)
                    {
                        FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

                        if (photo != null)
                        {
                            string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                            using Stream stream = await photo.OpenReadAsync();
                            using FileStream localFileStream = File.OpenWrite(localFilePath);
                            await stream.CopyToAsync(localFileStream);
                            User Updated = new();
                            Updated = UserDetail;
                            Updated.Avatar = localFilePath;
                            UserDetail = Updated;
                        }
                    }
                }
                else
                {
                    AppInfo.ShowSettingsUI();
                }

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private async Task PickPhoto()
        {
            try
            {
                await Permissions.RequestAsync<Permissions.StorageWrite>();
                var status = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();
                if (DeviceInfo.Platform == DevicePlatform.Android && int.Parse(DeviceInfo.VersionString) >= 13)
                {
                    status = PermissionStatus.Granted;
                }
                if (status == PermissionStatus.Granted)
                {
                    if (MediaPicker.Default.IsCaptureSupported)
                    {
                        FileResult photo = await MediaPicker.Default.PickPhotoAsync();
                        if (photo != null)
                        {
                            string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                            using Stream stream = await photo.OpenReadAsync();
                            using FileStream localFileStream = File.OpenWrite(localFilePath);
                            await stream.CopyToAsync(localFileStream);
                            User Updated = new();
                            Updated = UserDetail;
                            Updated.Avatar = localFilePath;
                            UserDetail = Updated;
                        }
                    }
                }
                else
                {
                    AppInfo.ShowSettingsUI();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        #endregion
    }
}

