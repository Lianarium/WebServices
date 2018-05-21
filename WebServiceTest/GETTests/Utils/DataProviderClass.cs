using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using Newtonsoft.Json;
using NUnit.Framework;
using POSTtests;
using RequestBuilderPattern;
using RestSharp;

namespace GETTests.Utils
{
    public class DataProviderClass
    {


        public static string GetData()
        {
            RestClient client = new RestClient(DataSource.Url);
            RestRequest request = new RestRequest();

            Post post = new Post
            {
                UserId = "123",
                Body = "postBody",
                Id = "1234",
                Title = "postTitle"

            };

            var json = request.JsonSerializer.Serialize(post);

            return json;
        }


        public static IEnumerable TestCases
        {

            get
            {
                yield return new TestCaseData(DataSource.PostsResource, GetData(), Method.POST).Returns(DataSource.StatusCreated);
                yield return new TestCaseData(DataSource.PostsResource, GetData(), Method.GET).Returns(DataSource.StatusOK);
                yield return new TestCaseData(DataSource.PostsResource, GetData(), Method.HEAD).Returns("Random");
                 
            }
        }

        private IEnumerable TestCasesLists
        {
            get
            {
                foreach (var dataSet in CSVReader.GetListOfDataSets())
                {
                    yield return dataSet;
                }
            }

        }
    }
}

