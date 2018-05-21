using RestSharp;
using System.Collections.Generic;

namespace RequestBuilderPattern
{
    public class Request
    {

       public RestClient RestClient { get; set; }

        public RestSharp.RestRequest RestRequest { get; set; }

        public IRestResponse RestResponse { get; set; }

        //public List<Parameter> RequestHeaders { get; set; }

        public string RequestBody { get; set; }

        public string ResponseContent { get; set; }

    }
}