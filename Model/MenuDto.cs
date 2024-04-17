using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplication.Model
{
    public class MenuDto
    {
        [JsonProperty("data")]
        public UserDto Data { get; set; }
        [JsonProperty("support")]
        public SupportDto Support { get; set; }    
    }
}
