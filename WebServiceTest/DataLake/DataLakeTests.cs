using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using POSTtests;
using RequestBuilderPattern;
using RestSharp;

namespace DataLake
{
    [TestFixture]
    public class DataLakeTests
    {

        private RestClient client;
        private HttpStatusCode OkCode = HttpStatusCode.OK;
        private RestRequest tokenRequest;
        private IRestResponse tokenResponse;

        private string dataLakeResource = "/webhdfs/v1/?op=LISTSTATUS";
        
        private string access_token;

        [SetUp]
        public void GetToken()
        {
            string resource = "/parexelcloud.onmicrosoft.com/oauth2/token";
            var postMethod = Method.POST;
            string[] parameterNames = new string[] { "grant_type" , "resource" , "client_id" , "client_secret" };
            string[] parameterValues = new string[] { "client_credentials", "https://management.core.windows.net/", "9aa47fdc-268e-4eae-8c48-d3286b32ba0b", "X3ZRG4Qmg35WGHLC28JUsvhRDWzFVi2DEHrETDXzI/Y=" };
            client = new RestClient(DataSource.MicrosoftLoginUrl);

            tokenRequest = new CustomRestRequest().WithResource(resource).WithMethod(postMethod)
                .WithParameters(parameterNames, parameterValues).Build();

            tokenResponse = client.Execute(tokenRequest);

            access_token = tokenResponse.Content.Split(':').Last().Trim('}', '{', '"');

        }

        [Test]
        public void GettingTokenSmokeTest()
        {           
            Assert.IsTrue(tokenResponse.Content.Contains("access_token"), "Can't get access token!");
        }

        [Test]
        public void ResponseContentTypeTest()
        {
            
            RestClient dataLakeClient = new RestClient(DataSource.AzureUrl);
            RestRequest dataLakeRequest = new CustomRestRequest().WithResource(dataLakeResource).WithMethod(Method.GET).WithHeader("Authorization", "Bearer" + access_token).Build();

            var dataLakeResponse = dataLakeClient.Execute(dataLakeRequest);

            Assert.IsTrue(dataLakeResponse.ContentType.Contains("application/json"));
        }


    }
}
