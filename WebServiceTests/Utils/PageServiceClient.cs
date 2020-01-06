using FluentAssertions;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebServiceTests.Models;

namespace WebServiceTests.Utils
{
    internal class PageServiceClient
    {
        private readonly RestClient client;
        private readonly PageServiceRequestBuilder requestBuilder;

        public PageServiceClient(Configuration configuration)
        {
            this.client = new RestClient(configuration.PageServiceBaseUrl);
            this.requestBuilder = new PageServiceRequestBuilder(configuration);
        }

        public async Task<PageService> GetPostServiceByIdAsync(string id)
        {
            var request = this.requestBuilder.CreateGetPageServiceByIdRequest(id)
                .WithAuthorizationHeader()
                .Build();
            var response = await this.client.ExecuteTaskAsync<PageService>(request);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            return JsonConvert.DeserializeObject<PageService>(response.Content);
        }

        public async Task<PageService> PostPageServiceAsync(PageService pageService)
        {
            var request = this.requestBuilder.CreatePostPageService(pageService)
                .WithAuthorizationHeader()
                .Build();
            var response = await this.client.ExecuteTaskAsync<PageService>(request);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            return JsonConvert.DeserializeObject<PageService>(response.Content);
        }

        public async Task<IRestResponse> ExecuteRequestAsync(IRestRequest request)
        {
            return await this.client.ExecuteTaskAsync(request);
        }
    }
}
