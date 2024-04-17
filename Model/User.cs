using CommunityToolkit.Mvvm.ComponentModel;
using System.Text.Json.Serialization;

namespace DemoApplication.Model
{
    public partial class User :ObservableObject
    {
        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private string? email;

        [ObservableProperty]
        private string? firstName;

        [ObservableProperty]
        private string? last_name;

        [ObservableProperty]
        private string? avatar;
    }
}
