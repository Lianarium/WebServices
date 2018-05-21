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

            RestClient client = new RestClient("https://jsonplaceholder.typicode.com");
            RestRequest request = new RestRequest("/posts", Method.POST);

            Post post = new Post
            {
                UserId =  "123",
                Body = "postBody",
                Id = "1234",
                Title = "postTitle"
               
            };

            var json = request.JsonSerializer.Serialize(post);
            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);


          
            Console.WriteLine(response.Content.ToString());

            CSVReader.Read();
        }
    }
}
