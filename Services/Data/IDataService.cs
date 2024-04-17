using DemoApplication.Model;
using System;
namespace DemoApplication.Services
{
	public interface IDataService
	{
         Task<LoginResponse> LoginAsync(LoginRequest request);

        Task<UsersDto> ListUsers();

        Task<MenuDto> GetProfile();
    }
}

