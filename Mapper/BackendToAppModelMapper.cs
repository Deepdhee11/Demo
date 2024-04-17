using DemoApplication.Mapper.Converter;
using DemoApplication.Model;
using System.Text;

namespace DemoApplication.Mapper
{
    public static class BackendToAppModelMapper
    {
        /// <summary>
        /// Mapping UsersDto To users
        /// </summary>
        /// <param name="usersDto"></param>
        /// <returns></returns>
        public static Users GetUsers(UsersDto usersDto)
        {
            if(usersDto == null)
            {
                return new Users();
            }
            var converter = new UsersDtoToUsersConverter(); 
            return converter.Convert(usersDto);
        }

        /// <summary>
        /// Mapping UserDto To user
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        public static IEnumerable<User> GetUserData(IEnumerable<UserDto> userDto)
        {
            if(userDto == null)
            {
                return Enumerable.Empty<User>();
            }
            var Converter = new UserDtoToUserConverter();
            return userDto.Select(Converter.Convert);
        }

        /// <summary>
        /// Mapping supportDto To support
        /// </summary>
        /// <param name="supportDto"></param>
        /// <returns></returns>
        public static Support GetUserSupportData(SupportDto supportDto)
        {
            if (supportDto == null)
            {
                return new Support();
            }
            var converter = new SupportDtoToSupportConverter();
            return converter.Convert(supportDto);
        }

        public static User GetProfile(UserDto userDto)
        {
            if (userDto == null)
            {
                return new User();
            }
            var converter = new UserDtoToUserConverter();
            return converter.Convert(userDto);
        }
    }
}
