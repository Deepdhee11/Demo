using System;
using DemoApplication.Model;
using Refit;

namespace DemoApplication.Services
{
    [Headers("Content-Type: application/json")]
    public interface IApiService 
	{
        [Post("/api/login")]
        [Headers("Content-Type: application/json")]
        Task<LoginResponse> LoginAsync([Body(BodySerializationMethod.Serialized)] LoginRequest request);

        [Get("/api/users?page=2")]
        Task<UsersDto> ListUsers();

        [Get("/api/users/2")]
        Task<MenuDto> GetProfile();
    }
}

