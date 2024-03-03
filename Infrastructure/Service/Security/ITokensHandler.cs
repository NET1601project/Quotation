using Domain;
using Infrastructure.Common.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Security
{
    public interface ITokensHandler
    {
        AccessToken CreateAccessToken(Account customer);
        RefreshToken TakeRefreshToken(string token, string userName);
        void RevokeRefreshToken(string token, string userName);
        string ClaimsFromToken(string token);

        string ClaimsFromToken();
    }
}
