using Newtonsoft.Json;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using Java.Net;
using System.Net.Http.Json;
using Android.Net;
using System.Text.Json;
using System.Text;
using DemoApplication.Model;
using System.Net.Http.Headers;
using Kotlin.Contracts;
namespace DemoApplication.Services
{
    public class DataService : IDataService
    {
        private readonly IApiService _apiService;
        HttpClient _client;
        public DataService(IApiService apiService)
        {
            _client = new HttpClient();
            _apiService = apiService;
        }


        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {    
            LoginResponse response = new();
            try
            {
                response = await _apiService.LoginAsync(request);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            return response;
        }
        public async Task<UsersDto> ListUsers()
        {
            var response = new UsersDto();
            try
            {
                response = await _apiService.ListUsers();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return response;
        }

        public async Task<MenuDto> GetProfile()
        {
            var response = new MenuDto();
            try
            {
                response = await _apiService.GetProfile();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return response;
        }
    }
}

