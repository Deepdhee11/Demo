using DemoApplication.Model;

namespace DemoApplication.Mapper.Converter
{
    public class UsersDtoToUsersConverter :ConverterBase<UsersDto,Users>
    {
        protected override Users ConvertImpl(UsersDto source)
        {
            return new Users()
            {
                Page = source.Page,
                Per_page = source.Per_page,
                Total = source.Total,
                Total_pages = source.Total_pages,
                Data = BackendToAppModelMapper.GetUserData(source.Data),
                Support = BackendToAppModelMapper.GetUserSupportData(source.Support)
            };
        }
    }
}
