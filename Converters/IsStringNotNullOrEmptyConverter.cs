using CommunityToolkit.Maui.Converters;
using System.Globalization;

namespace DemoApplication.Converters
{
    public class IsStringNotNullOrEmptyConverter : BaseConverterOneWay<string?,bool>
    {
        public override bool DefaultConvertReturnValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override bool ConvertFrom(string value, CultureInfo? culture)
            => !string.IsNullOrEmpty(value);
    }
}
