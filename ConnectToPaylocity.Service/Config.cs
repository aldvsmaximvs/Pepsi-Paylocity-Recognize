using IdentityServer4.Models;

namespace ConnectToPaylocity.Service
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetAllApiResource()
        {
            return new List<ApiResource>
            {
                new ApiResource("WebLinkAPI","Web Link API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "D6SiJoUMKkmdWFFdwm1cnS04NTg1MzYwMDc2MTI4NzI4ODg2",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("uZ5B1ugFVdPNbSQKFN4VZaWesoeK2Us54WBJqigWq8sZrfzcLkkHt10vJoSGGcVMJyE0Id+OBuJnyBQcPg6SPw==")
                    },
       
                    AllowedScopes = {"WebLinkAPI" }
                }
            };
        }
    }
}
