﻿//using Microsoft.IdentityModel.Tokens;
//using MiniCRMJWT.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Tokens;

using System.Linq;
using System.Security.Claims;
//using System.Security.Claims;
using System.Text;
using System.Web;

namespace DataAccessCore.Identity
{
    public class AuthenticationModule
    {
        private const string communicationKey = "GQDstc21ewfffffffffffFiwDffVvVBrk";
        System.IdentityModel.Tokens.SecurityKey signingKey = new InMemorySymmetricSecurityKey(Encoding.UTF8.GetBytes(communicationKey));


        // The Method is used to generate token for user
        public string GenerateTokenForUser(string userName, int userId)
        {


            var signingKey = new InMemorySymmetricSecurityKey(Encoding.UTF8.GetBytes(communicationKey));
            var now = DateTime.UtcNow;
            var signingCredentials = new System.IdentityModel.Tokens.SigningCredentials(signingKey,
               System.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature, System.IdentityModel.Tokens.SecurityAlgorithms.Sha256Digest);

            var claimsIdentity = new ClaimsIdentity(new List<System.Security.Claims.Claim>()
            {
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, userName),
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.NameIdentifier, userId.ToString()),
            }, "Custom");

            var securityTokenDescriptor = new System.IdentityModel.Tokens.SecurityTokenDescriptor()
            {
                AppliesToAddress = "http://www.example.com",
                TokenIssuerName = "self",
                Subject = claimsIdentity,
                SigningCredentials = signingCredentials,
                Lifetime = new Lifetime(now, now.AddYears(1)),
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var plainToken = tokenHandler.CreateToken(securityTokenDescriptor);
            var signedAndEncodedToken = tokenHandler.WriteToken(plainToken);

            return signedAndEncodedToken;

        }

        /// Using the same key used for signing token, user payload is generated back
        public JwtSecurityToken GenerateUserClaimFromJWT(string authToken)
        {

            var tokenValidationParameters = new System.IdentityModel.Tokens.TokenValidationParameters()
            {
                ValidAudiences = new string[]
                      {
                    "http://www.example.com",
                      },

                ValidIssuers = new string[]
                  {
                      "self",
                  },
                IssuerSigningKey = signingKey
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            System.IdentityModel.Tokens.SecurityToken validatedToken;

            try
            {

                tokenHandler.ValidateToken(authToken, tokenValidationParameters, out validatedToken);
            }
            catch (Exception)
            {
                return null;

            }

            return validatedToken as JwtSecurityToken;

        }

        public JWTAuthenticationIdentity PopulateUserIdentity(JwtSecurityToken userPayloadToken)
        {
            string name = ((userPayloadToken)).Claims.FirstOrDefault(m => m.Type == "unique_name").Value;
            string userId = ((userPayloadToken)).Claims.FirstOrDefault(m => m.Type == "nameid").Value;
            return new JWTAuthenticationIdentity(name) { UserId = Convert.ToInt32(userId), UserName = name };

        }
    }
}