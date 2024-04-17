using DemoApplication.Model;

namespace DemoApplication.Mapper.Converter
{
    public class SupportDtoToSupportConverter : ConverterBase<SupportDto, Support>
    {
        protected override Support ConvertImpl(SupportDto source)
        {
            return new Support()
            {
                url = source.url,
                text = source.text
            };
        }
    }        
}
