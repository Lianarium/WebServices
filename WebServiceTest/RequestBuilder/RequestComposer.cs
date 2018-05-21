using RequestBuilderPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestBuilderPattern
{
    public class RequestComposer
    {
       
            public Request ComposeRequest(RequestBuilder requestBuilder)
            {
                requestBuilder.CreateRequest();
                requestBuilder.SetRestClient();
                requestBuilder.SetRestRequest();
                requestBuilder.SetHeaders();
                requestBuilder.SetBody();
                requestBuilder.SetRestResponse();
                return requestBuilder.Request;
            }
        
    }
}
