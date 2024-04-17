using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace DemoApplication.Model
{
	public class Users
	{
        
        public int Page { get; set; }

        
        public int Per_page { get; set; }

        
        public int Total { get; set; }

        
        public int Total_pages { get; set; }

       
        public IEnumerable<User>? Data { get; set; }
        
        public Support? Support { get; set; }
    }
    public class Support
    {
        
        public string? url { get; set; }
       
        public string? text { get; set; }
    }
}

