using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildGrowth.Services
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync();

        Task<bool> LogoutAsync();

        Task<string> GetTokenAsync();

        bool IsAuthenticated { get; }

        /// <summary>
        /// Kevin's hopefully super smart hack
        /// </summary>
        /// <returns>Task</returns>
        void BypassAuthentication();
    }
}
