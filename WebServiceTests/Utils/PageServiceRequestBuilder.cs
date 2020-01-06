using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceTests.Models;

namespace WebServiceTests.Utils
{
    internal class PageServiceRequestBuilder
    {
        private readonly Configuration configuration;

        private IRestRequest request;

        public PageServiceRequestBuilder(Configuration configuration)
        {
            this.configuration = configuration;
        }

        public PageServiceRequestBuilder CreateGetPageServiceByIdRequest(string fileId)
        {
            this.request = new RestRequest(this.configuration.GetPageByIdPath, Method.GET)
                .AddUrlSegment("id", fileId);

            return this;
        }

        public PageServiceRequestBuilder CreatePostPageService(
            PageService postService)
        {
            this.request = new RestRequest(this.configuration.PostPageByPath, Method.POST)
                .AddJsonBody(JsonConvert.SerializeObject(postService));

            return this;
        }

        public PageServiceRequestBuilder WithAuthorizationHeader()
        {
            this.request.AddHeader("authorization", this.configuration.AuthorizationToken);

            return this;
        }

        public IRestRequest Build()
        {
            return this.request;
        }
    }
}
