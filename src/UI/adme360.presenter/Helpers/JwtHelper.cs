using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace adme360.presenter.Helpers
{
    public static class JwtHelper
    {
        public static string ExtractRoleFromToken(string jwtToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwtToken);
            var tokenClaims = handler.ReadToken(jwtToken) as JwtSecurityToken;
            
            var role = tokenClaims?.Claims.First(claim => claim.Type == "role").Value;

            return role;
        }
    }
}
