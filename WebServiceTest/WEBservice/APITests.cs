using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using Newtonsoft.Json;
using NUnit.Framework;
using POSTtests;
using RequestBuilderPattern;
using RestSharp;

namespace WEBservice
{
    [TestFixture]
    public class ApiTests
    {
        RestClient Client;

        [SetUp]
        public void CreateClient()
        {
            Client = new RestClient(DataSource.Url);
        }

        [Test]
        public void ResponseStatusTest()
        {
            HttpStatusCode ok = HttpStatusCode.OK;
            var request = new RestRequest(DataSource.PostsResource, Method.GET);
            var response = Client.Execute(request);
            Assert.AreEqual( ok , response.StatusCode, "" );
            
        }

        [Test]
        public void ContentTypeTest()
        {
            var request = new RestRequest(DataSource.UsersResource, Method.GET);
            var response = Client.Execute(request);
            Assert.IsTrue(response.ContentType.Contains("application/json")&& response.ContentType.Contains("charset=utf-8"));
        }

        [Test]
        public void ResponseBodyTest()
        {
            int expectedlength = 10;
            var request = new RestRequest(DataSource.UsersResource, Method.GET);
            var response = Client.Execute(request);
            var data = response.Content;
            User[] users = JsonConvert.DeserializeObject<User[]>(data);
            Assert.AreEqual(expectedlength, users.Length);
        }
    }
}
