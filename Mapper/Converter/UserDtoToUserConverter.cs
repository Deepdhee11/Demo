using DemoApplication.Model;

namespace DemoApplication.Mapper.Converter
{
    public class UserDtoToUserConverter : ConverterBase<UserDto, User>
    {
        protected override User ConvertImpl(UserDto source)
        {
            return new User()
            {
                Id = source.id,
                Email = source.Email,
                FirstName = source.FirstName,
                Last_name = source.last_name,
                Avatar = source.Avatar
            };
        }
    }
}
