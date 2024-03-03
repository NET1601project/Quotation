using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Model
{
    public class AuthenResponseMessToken
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public long Expiration { get; set; }

    }
}
