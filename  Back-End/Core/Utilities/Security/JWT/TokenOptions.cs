using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class TokenOptions
    {
        public String Audience { get; set; }
        public String Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        public String SecurityKey { get; set; }


    }
}
