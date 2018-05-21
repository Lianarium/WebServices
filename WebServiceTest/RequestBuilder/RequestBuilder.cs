using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestBuilderPattern
{
   public abstract class RequestBuilder
    {
        public Request Request;
        public void CreateRequest()
        {
            Request = new Request();
        }

        public abstract void SetRestClient();

        public abstract void SetRestRequest();

        public abstract void SetRestResponse();

        public abstract void SetHeaders();
        public abstract void SetBody();
       
    }
}
