using System;
using System.IO;
using System.Net.Http;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;

namespace HashtagAggregator.Tests.Integration
{
    public class TestFixture<TStartup> : IDisposable
    {
        private const string SolutionName = "HashtagAggregator.sln";
        private readonly TestServer server;

        public HttpClient Client { get; }

        public TestFixture() : this(Path.Combine("src"))
        {
        }

        protected TestFixture(string solutionRelativeTargetProjectParentDir)
        {
            var startupAssembly = typeof(TStartup).GetTypeInfo().Assembly;
            var contentRoot = GetProjectPath(solutionRelativeTargetProjectParentDir, startupAssembly);

            var builder = new WebHostBuilder()
                .UseContentRoot(contentRoot)
                .ConfigureServices(InitializeServices)
                .UseEnvironment("Testing")
                .UseStartup(typeof(TStartup));

            server = new TestServer(builder);

            Client = server.CreateClient();
            Client.BaseAddress = new Uri("http://localhost");
        }

        private void InitializeServices(IServiceCollection services)
        {
            var startupAssembly = typeof(TStartup).GetTypeInfo().Assembly;

            // Inject a custom application part manager. Overrides AddMvcCore() because that uses TryAdd().
            var manager = new ApplicationPartManager();
            manager.ApplicationParts.Add(new AssemblyPart(startupAssembly));

            manager.FeatureProviders.Add(new ControllerFeatureProvider());
            manager.FeatureProviders.Add(new ViewComponentFeatureProvider());

            services.AddSingleton(manager);
        }

        private static string GetProjectPath(string solutionRelativePath, Assembly startupAssembly)
        {
            var projectName = startupAssembly.GetName().Name;
            var applicationBasePath = PlatformServices.Default.Application.ApplicationBasePath;

            // Find the folder which contains the solution file. We then use this information to find the target
            // project which we want to test.
            var directoryInfo = new DirectoryInfo(applicationBasePath);
            do
            {
                var solutionFileInfo = new FileInfo(Path.Combine(directoryInfo.FullName, SolutionName));
                if (solutionFileInfo.Exists)
                {
                    return Path.GetFullPath(Path.Combine(directoryInfo.FullName, solutionRelativePath, projectName));
                }
                directoryInfo = directoryInfo.Parent;
            }
            while (directoryInfo.Parent != null);

            throw new Exception($"Solution root could not be located using application root {applicationBasePath}.");
        }

        public void Dispose()
        {
            Client?.Dispose();
            server?.Dispose();
        }
    }
}
