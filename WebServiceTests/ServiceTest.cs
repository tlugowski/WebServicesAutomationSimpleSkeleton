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
using WebServiceTests.Utils;
using Xunit;

namespace WebServiceTests
{
    public class ServiceTest
    {
        private readonly PageServiceClient client;
        private readonly PageServiceRequestBuilder requestBuilder;

        [Fact]
        public async void GetTomkowy()
        {
            var request = this.requestBuilder
                .CreateGetPageServiceByIdRequest(new PageService().Location)
                .Build();
            var response = await this.client.ExecuteRequestAsync(request);
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
        [Fact]
        public async void GetPostServiceByIdRequestWithoutAuthorizationHeader()
        {
            var request = this.requestBuilder
                .CreateGetPageServiceByIdRequest(Guid.NewGuid().ToString())
                .Build();
            var response = await this.client.ExecuteRequestAsync(request);
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async void PostPageServiceRequestWithoutAuthorization()
        {
            var request = this.requestBuilder.CreatePostPageService
                (new PageService())
                .Build();
            var response = await this.client.ExecuteRequestAsync(request);
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        //[Test]
        //[InlineData("xxx")]
        //public async void GetEnrollmentAttachmentByIdRequestWithIncorrectlyFormattedId(string incorrectGuid)
        //{
        //    var request = this.requestBuilder.CreateGetPageServiceByIdRequest(incorrectGuid)
        //        .WithAuthorizationHeader()
        //        .Build();
        //    var response = await this.client.ExecuteRequestAsync(request);
        //    response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        //}

        //[Test]
        //[InlineData("amFraXMgdGV4dA==", "*csv")]
        //public async void PostEnrollmentAttachmentWithHealthyFile(string fileData, string fileExtension)
        //{
        //    var enrollmentAttachmentToUpload = new PageService()
        //    {
        //        Id = Guid.NewGuid().ToString(),
        //        FileData = fileData,
        //        FileExtension = fileExtension,
        //    };

        //    var response = await this.client.PostEnrollmentAttachmentAsync(enrollmentAttachmentToUpload);

        //    response.Should().BeEquivalentTo(new PageService()
        //    {
        //        Id = enrollmentAttachmentToUpload.Id,
        //        FileData = null,
        //        FileExtension = enrollmentAttachmentToUpload.FileExtension,
        //    });
        //    var uploadedAttachment = await this.client.GetEnrollmentAttachmentByIdAsync(enrollmentAttachmentToUpload.Id);
        //    uploadedAttachment.Should().BeEquivalentTo(enrollmentAttachmentToUpload);
        //}

        //[Test]
        //public async void PostEnrollmentAttachmentWithFileContainingMalware()
        //{
        //    var id = Guid.NewGuid().ToString();
        //    var request = this.requestBuilder.CreatePostEnrollmentAttachmentRequest(
        //            new PageService()
        //            {
        //                Id = id,
        //                FileData =
        //                    "WDVPIVAlQEFQWzRcUFpYNTQoUF4pN0NDKTd9JEVJQ0FSLVNUQU5EQVJELUFOVElWSVJVUy1URVNULUZJTEUhJEgrSCo=",
        //                FileExtension = "*jpg",
        //            })
        //        .WithAuthorizationHeader()
        //        .Build();

        //    var postResponse = await this.client.ExecuteRequestAsync(request);

        //    postResponse.StatusCode.Should().Be(HttpStatusCode.Conflict);
        //    var enrollmentAttachmentResponse = JsonConvert.DeserializeObject<EnrollmentAttachmentResponse>(postResponse.Content);
        //    enrollmentAttachmentResponse.Success.Should().BeFalse();
        //    enrollmentAttachmentResponse.ErrorCode.Should().Be("FileContainsVirus");
        //    enrollmentAttachmentResponse.Message.Should().Be("The file contains a virus.");
        //    var getResponse = await this.client.ExecuteRequestAsync(
        //        this.requestBuilder.CreateGetEnrollmentAttachmentByIdRequest(id)
        //            .WithAuthorizationHeader()
        //            .Build());
        //    getResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        //}
    }
}
