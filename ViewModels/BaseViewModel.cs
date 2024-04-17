using CommunityToolkit.Mvvm.ComponentModel;
using DemoApplication.Model;
using DemoApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplication.ViewModels
{
    public partial class BaseViewModel: ObservableObject
    {
        IDataService _dataService;

        public BaseViewModel()
        {
        }

        public BaseViewModel(IDataService dataService)
        {
            _dataService = dataService;
        }

        //public async Task<Users> GetListUsers() 
        //{
        //    return await _dataService.ListUsers();
        //}
    }
}
