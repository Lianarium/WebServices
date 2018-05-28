using GETTests;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using POSTtests;
using RequestBuilderPattern;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GETTests.Utils;


namespace Runner
{
    public class Program
    {
        public static void Main(string[] args)
        {

           RestClient client = new RestClient("https://login.microsoftonline.com");
           RestRequest POSTrequest = new RestRequest("/parexelcloud.onmicrosoft.com/oauth2/token", Method.POST);
           POSTrequest.AddParameter("grant_type", "client_credentials");
           POSTrequest.AddParameter("resource", "https://management.core.windows.net/");
           //POSTrequest.AddParameter("client_id", "9aa47fdc-268e-4eae-8c48-d3286b32ba0b");
           //POSTrequest.AddParameter("client_secret", "X3ZRG4Qmg35WGHLC28JUsvhRDWzFVi2DEHrETDXzI/Y=");

            POSTrequest.AddBody("grant_type=client_credentials&resource=https://management.core.windows.net/&client_id=9aa47fdc-268e-4eae-8c48-d3286b32ba0b &client_secret=X3ZRG4Qmg35WGHLC28JUsvhRDWzFVi2DEHrETDXzI/Y=");

           var response = client.Execute(POSTrequest);
           Console.WriteLine(response.StatusCode.ToString());

           string token = response.Content.Split(':').Last().Trim('}', '{', '"');


            Console.WriteLine(token);

            RestClient dataLakeClient = new RestClient("https://pxlweusbxteam5datalake.azuredatalakestore.net"); 


            RestRequest GETrequest = new RestRequest("/webhdfs/v1/?op=LISTSTATUS", Method.GET);

            GETrequest.AddHeader("Authorization", "Bearer " + token);

            var dataLakeResponse = dataLakeClient.Execute(GETrequest);

            Console.WriteLine(dataLakeResponse.StatusCode);

            Console.WriteLine(dataLakeResponse.Content);

            Console.WriteLine("hello my friend");



        }
    }
}
