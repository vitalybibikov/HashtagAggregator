using System.Collections.Generic;
using IdentityServer4.Models;

namespace MyStudyProject.IdentityServer
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource
                {
                    Name = "StatisticsAPI",
                    DisplayName = "Statistics API",
                    Description = "Statistics API Access",
                    Scopes = new List<Scope>
                    {
                        new Scope("StatisticsAPI"),
                    }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "StatisticsAPIСlient",
                    ClientName = "Statistics API Сlient",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris = { "http://localhost:5005/twitter-oidc" },
                    AllowedScopes = { "StatisticsAPI" }
                }
            };
        }
    }
}