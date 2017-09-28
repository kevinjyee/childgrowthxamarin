
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace ChildGrowth.Services
{
    public interface IAuthenticator
    {
        Task<AuthenticationResult> Authenticate(string authority, string resource, string clientId, string returnUri);

        Task<bool> DeAuthenticate(string authority);

        Task<string> FetchToken(string authority);
    }
}
