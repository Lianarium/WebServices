
using RestSharp;


namespace RequestBuilderPattern
{
    public class PostRequestBuilder : RequestBuilder
    {
        //Do we need the same methods for body parameters and particular headers like following:
        //public override void setBodyParameterId()
        //public override void setContentType()
        //?
        public override void SetBody()
        {
            
            this.Request.RestRequest.AddJsonBody(new { id = "123", title = "title" });
        }

        public override void SetHeaders()
        {
            this.Request.RestRequest.AddHeader("Connection", "Keep-Alive");
           
        }

        public override void SetRestClient()
        {
           //this.Request.RestClient = new RestClient(DataSource.Url);
        }

        public override void SetRestRequest()
        {
           //this.Request.RestRequest = new RestSharp.RestRequest(DataSource.PostsResource, DataSource.Method);
        }

        public override void SetRestResponse()
        {
            this.Request.RestResponse = this.Request.RestClient.Execute(this.Request.RestRequest);
        }
    }
}
