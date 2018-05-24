using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSTtests
{
   [Serializable]
   public class Post
    {
       [JsonProperty("userId")]
        public string UserId { get; set; }

       [JsonProperty("Id")]
        public string Id { get; set; }

       [JsonProperty("Title")]
        public string Title { get; set; }

       [JsonProperty("Body")]
        public string Body { get; set; }
    }
}
