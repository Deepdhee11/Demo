using Android.Service.Autofill;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DemoApplication.Mapper;
using DemoApplication.Model;
using DemoApplication.Services;
using Newtonsoft.Json;

namespace DemoApplication.ViewModels
{
    [QueryProperty(nameof(UpdatedUserDetail), "userdetail")]
    public partial class ProfileViewModel : ViewModelBase
    {
        #region Private
        private readonly IDataService _dataService;
        private string? updatedUserDetail;
        #endregion
        #region Observable Properties
        [ObservableProperty]
        private Users userDetail = new();
        //[ObservableProperty]
        //private ObservableCollection<User> data;
        
        [ObservableProperty]
        private bool isRefresh;
        #endregion
        #region Public Properties
        public string UpdatedUserDetail
        {
            get { return updatedUserDetail; }
            set
            {
                User data = JsonConvert.DeserializeObject<User>(value);  
                UpdateExistingData(data);
            }
        }
        #endregion

        #region Constructor
        public ProfileViewModel(IDataService dataService)
        {
            _dataService = dataService;
            Initialise();
        }
        #endregion

        #region Methods
        private void UpdateExistingData(User data)
        {
            try
            {
                foreach (User users in UserDetail.Data.ToList())
                {
                    if (users.Id.Equals(data.Id))
                    {
                        users.Avatar = "";
                        users.Avatar = data.Avatar;
                        OnPropertyChanged(nameof(UserDetail));
                    }
                }
            }
            catch (System.Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private async Task Initialise()
        {
            var userData = await _dataService.ListUsers();
            UserDetail = BackendToAppModelMapper.GetUsers(userData);
            //Data = new ObservableCollection<User>(UserDetail?.Data);
        }

        #endregion

        #region Commands
        [RelayCommand]
        private void NavigateToDetail(User user)
        {
            try
            {
                var navigationParameter = new Dictionary<string, object> { { "UserDetail", user } };
                Shell.Current.GoToAsync($"DetailView", (IDictionary<string, object>)navigationParameter);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        [RelayCommand]
        private async Task Refresh()
        {
            try
            {
                IsRefresh = true;
                await Initialise();
                IsRefresh = false;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        #endregion
    }
}

