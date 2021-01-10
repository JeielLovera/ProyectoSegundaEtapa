using System;

namespace Proyecto.Infrastructure.Context.Security
{
    public class UserToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
