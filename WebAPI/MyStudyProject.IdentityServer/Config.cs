using System.Collections.Generic;

using IdentityServer4;
using IdentityServer4.Models;

namespace MyStudyProject.IdentityServer
{
    public class Config
    {
        private const string StatisticsApiName = "statisticsapi";


        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource(StatisticsApiName, "Statistics API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "statisticsapiclient",
                    ClientName = "Statistics API Сlient",
                    AllowedGrantTypes = GrantTypes.Implicit,

                    RedirectUris = { "http://localhost:3000/login-callback" },
                    PostLogoutRedirectUris = { "http://localhost:3000" },
                    AllowedCorsOrigins = { "http://localhost:3000" },
                    AllowedScopes =
                    {
                        StatisticsApiName,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email
                    },
                    AllowAccessTokensViaBrowser =  true,
                    AllowRememberConsent = false,
                    RequireConsent = false
                }
            };
        }
    }
}