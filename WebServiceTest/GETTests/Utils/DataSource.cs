using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSTtests
{
   public class DataSource
    {
        private static string url = "https://jsonplaceholder.typicode.com";

        private static string microsortLoginUrl = "https://login.microsoftonline.com";

        private static string azureUrl = "https://pxlweusbxteam5datalake.azuredatalakestore.net";


        private static string postsResource = "/posts";

        private static string usersResource = "/users";

        private static Method method = Method.POST;

        private static string statusCreated = "Created";

        private static string statusOK = "OK";



        public static string Url { get => url; set => url = value; }

        public static string MicrosoftLoginUrl { get => microsortLoginUrl; set => microsortLoginUrl = value; }

        public static string AzureUrl { get => azureUrl; set => azureUrl = value; } 

        public static string PostsResource { get => postsResource; set => postsResource = value; }

        public static string UsersResource { get => usersResource; set => usersResource = value; }

        public static Method Method { get => method; set => method = value; }

        public static string StatusCreated { get => statusCreated; set => statusCreated = value; }

        public static string StatusOK { get => statusOK; set => statusOK = value; }
    }
    
}
