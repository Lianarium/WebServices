using NUnit.Framework;
using RequestBuilderPattern;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GETTests.Utils;


namespace POSTtests

{
    [TestFixture]
    public class POSTtests
    {
        RequestComposer requestComposer;
        RequestBuilder builder;
        Request postRequest;
        private RestClient client;
      


        [SetUp]
        public void TestInit()
        {
            client = new RestClient("https://jsonplaceholder.typicode.com");
           
        }

        [Test]
        public void  CreatePostTest()
        {
            requestComposer = new RequestComposer();
            builder = new PostRequestBuilder();
            postRequest = requestComposer.ComposeRequest(builder);
            string expectedStatusCode = "Created";
            Assert.AreEqual(expectedStatusCode, postRequest.RestResponse.StatusCode.ToString(), "New post wasn't created");
        }



        [Test, TestCaseSource(typeof(DataProviderClass), "TestCases")]
        public string CreateRequestWithResource_Method_Body_Test(string resource, string body, Method method)
        {
            RestRequest request = new CustomRestRequest().WithResource(resource).WithMethod(method).WithBody(body).Build();
            IRestResponse response = client.Execute(request);
            return response.StatusCode.ToString();
        }

        [Test, TestCaseSource(typeof(DataProviderClass), "TestCasesLists")]
        public string CreateDifferentPostsTest(string resource)
        {
            RestRequest request = new CustomRestRequest().WithResource(resource).Build();
            IRestResponse response = client.Execute(request);
            return response.StatusCode.ToString();
        }
    }
}
