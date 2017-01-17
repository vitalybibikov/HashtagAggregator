using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Xunit;

namespace MyStudyProject.Tests.Integration
{
    public class StatisticsControllerTests :  IClassFixture<TestFixture<Startup>>
    {
        private readonly HttpClient client;

        public StatisticsControllerTests(TestFixture<Startup> fixture)
        {
            client = fixture.Client;
        }

        //[Theory]
        //public async Task ReturnsInitialListOfBrainstormSessions()
        //{
        //    // Arrange
        //    var request = new HttpRequestMessage(new HttpMethod("GET"), "/");

        //    // Act
        //    var response = await client.SendAsync(request);

        //    // Assert
        //    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        //    var content = await response.Content.ReadAsStringAsync();

        //    Assert.Equal("Test response", content);
        //    Assert.False(response.Headers.Contains("Server"), "Should not contain server header");
        //}

    }
}
