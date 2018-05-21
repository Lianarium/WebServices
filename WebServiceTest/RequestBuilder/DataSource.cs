using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestBuilderPattern
{
   public class DataSource
    {
        private static string url = "https://jsonplaceholder.typicode.com";

        private static string postsResource = "/posts";

        private static string usersResource = "/users";

        private static Method method = Method.POST;

        private static string statusCreated = "Created";

        private static string statusOK = "OK";



        public static string Url { get => url; set => url = value; }

        public static string PostsResource { get => postsResource; set => postsResource = value; }

        public static string UsersResource { get => usersResource; set => usersResource = value; }

        public static Method Method { get => method; set => method = value; }

        public static string StatusCreated { get => statusCreated; set => statusCreated = value; }

        public static string StatusOK { get => statusOK; set => statusOK = value; }
    }
    
}
