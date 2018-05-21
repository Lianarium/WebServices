using System;
using Newtonsoft.Json;
using NServiceBus.Features;

using System.Linq;
using System.Text;
using RestSharp;


namespace RequestBuilderPattern

{

    /// <summary>
    /// custom request
    /// </summary>
    public class CustomRestRequest
    {
        /// <summary>
        /// Base internal request object 
        /// </summary>
        private readonly RestSharp.RestRequest request;

        /// <summary>
        /// request information
        /// </summary>
        private StringBuilder requestInformation = new StringBuilder();

        /// <summary>
        /// Data format
        /// </summary>
        private DataFormat baseDataFormat = DataFormat.Json;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomRestRequest"/> class.
        /// </summary>
        public CustomRestRequest()
        {
            this.request = new RestRequest();

        }

        /// <summary>
        /// Gets name of request
        /// </summary>
        public string Name => this.GetType().Name;

        /// <summary>
        ///  Adding resource to request
        /// </summary>
        /// <param name="resource">resource value</param>
        /// <returns>Request as <see cref="CustomRestRequest"/></returns>
        public CustomRestRequest WithResource(string resource)
        {
            this.request.Resource = resource;
            this.requestInformation.AppendLine($"Resource: {resource}");
            return this;
        }

        /// <summary>
        /// Adding method type to request
        /// </summary>
        /// <param name="method">adding method as <see cref="Method"/></param>
        /// <returns>Request as <see cref="CustomRestRequest"/></returns>
        public CustomRestRequest WithMethod(Method method)
        {
            this.request.Method = method;
            this.requestInformation.AppendLine($"Method: {method}");
            return this;
        }
        
        /// <summary>
        /// Adding a body to request with default request format as <see cref="DataFormat"/>
        /// </summary>
        /// <param name="body">string body</param>
        /// <returns>Request as <see cref="CustomRestRequest"/></returns>
        public CustomRestRequest WithBody(string body)
        {
            var contentType = this.request.XmlSerializer.ContentType;

            if (this.baseDataFormat == DataFormat.Json)
            {
                contentType = this.request.JsonSerializer.ContentType;
            }

            this.request.AddParameter(contentType, body, ParameterType.RequestBody);
            this.requestInformation.AppendLine($"Body: {body}");
            return this;
        }

        /// <summary>
        /// Adding a body to request
        /// </summary>
        /// <param name="body">string body</param>
        /// <param name="requestFormat">Request format</param>
        /// <returns>Request as <see cref="CustomRestRequest"/></returns>
        public CustomRestRequest WithBody(string body, DataFormat requestFormat)
        {
            this.WithRequestFormat(requestFormat);
            return this.WithBody(body);
        }


       

        /// <summary>
        /// Adding parameter to the request
        /// </summary>
        /// <param name="name">parameter name</param>
        /// <param name="value">parameter value</param>
        /// <returns>Request as <see cref="CustomRestRequest"/></returns>
        public CustomRestRequest WithParameter(string name, object value)
        {
            this.request.AddParameter(name, value);
            this.requestInformation.AppendLine($"Parameter: {name} with value {value}");
            return this;
        }

        /// <summary>
        /// Adding parameter to the request
        /// </summary>
        /// <param name="name">parameter name</param>
        /// <param name="value">parameter value</param>
        /// <param name="type">parameter type</param>
        /// <returns>Request as <see cref="CustomRestRequest"/></returns>
        public CustomRestRequest WithParameter(string name, object value, ParameterType type)
        {
            this.request.AddParameter(name, value, type);
            this.requestInformation.AppendLine($"Parameter: {name} with value {value} with type {type}");
            return this;
        }

        /// <summary>
        /// Adding parameters to the request
        /// </summary>
        /// <param name="names">Names of parameters.</param>
        /// <param name="values">Values of parameters.</param>
        /// <returns>Request as <see cref="CustomRestRequest"/></returns>
        public CustomRestRequest WithParameters(string[] names, object[] values)
        {
            ////todo
            if (names == null)
            {
                return this;
            }

            foreach (var name in names)
            {
                var index = names.ToList().IndexOf(name);
                if (values != null)
                {
                    this.WithParameter(name, values[index]);
                }
            }
            ////names.Zip(values, this.WithParameter);
            return this;
        }

        public CustomRestRequest WithParameters(string[] names, object[] values, ParameterType type)
        {
            ////todo
            if (names == null)
            {
                return this;
            }

            foreach (var name in names)
            {
                var index = names.ToList().IndexOf(name);
                if (values != null)
                {
                    this.WithParameter(name, values[index], type);
                }
            }
            ////names.Zip(values, this.WithParameter);
            return this;
        }

        /// <summary>
        /// Adding Url segment
        /// </summary>
        /// <param name="name">Url segment name</param>
        /// <param name="value">Url segment value</param>
        /// <returns>Request as <see cref="CustomRestRequest"/></returns>
        public CustomRestRequest WithUrlSegment(string name, string value)
        {
            this.request.AddUrlSegment(name, value);
            this.requestInformation.AppendLine($"Url segment: {name} with value {value}");
            return this;
        }

        /// <summary>
        /// Adding a header to request
        /// </summary>
        /// <param name="name">header name</param>
        /// <param name="value">header value</param>
        /// <returns>Request as <see cref="CustomRestRequest"/></returns>
        public CustomRestRequest WithHeader(string name, string value)
        {
            this.request.AddHeader(name, value);
            this.requestInformation.AppendLine($"Header: {name} with value {value}");
            return this;
        }

        /// <summary>
        /// Adding request format as <see cref="DataFormat"/>
        /// </summary>
        /// <param name="dataFormat">request format as <see cref="DataFormat"/></param>
        /// <returns>Request as <see cref="CustomRestRequest"/></returns>
        public CustomRestRequest WithRequestFormat(DataFormat dataFormat)
        {
            this.baseDataFormat = dataFormat;
            this.request.RequestFormat = dataFormat;
            this.requestInformation.AppendLine($"Request format: {dataFormat}");
            return this;
        }

        /// <summary>
        /// Adds the bytes to the Files collection with the specified file name
        /// </summary>
        /// <param name="name">parameter name</param>
        /// <param name="fileStream">file stream</param>
        /// <param name="fileName">file name</param>
        /// <param name="contentType">content type</param>
        /// <returns>Request as <see cref="CustomRestRequest"/></returns>
        public CustomRestRequest WithFile(string name, byte[] fileStream, string fileName, string contentType)
        {
            this.request.AddFile(name, fileStream, fileName, contentType);
            this.requestInformation.AppendLine($"name: {name}; file name: {fileName}; content type: {contentType}");
            return this;
        }

        /// <summary>
        /// Rest request builder
        /// </summary>
        /// <returns>request as <see cref="RestClient"/></returns>
        public RestSharp.RestRequest Build()
        {
            return this.request;
        }

        /// <summary>
        /// Detailed information
        /// </summary>
        /// <returns>formatted request</returns>
        public override string ToString()
        {
            return $"Request Information:\r\n {requestInformation}";
        }
    }
}
