using API.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TokenController : ApiController
    {
        [Route("api/Token/")]
        [HttpPost]

        public IHttpActionResult Authenticate(Usuario usuario)
        {
            if (usuario == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            bool isCredentialValid = (usuario.Username == "admin" && usuario.password == "123456");

            if(isCredentialValid)
            {
                var expireTime = ConfigurationManager.AppSettings["TOK_EXPIRE_MINUTES"];
                var accessToken = GenerateTokenJWT();
                var refreshToken = GenerateTokenJWT();
                Token token = new Token();
                token.AccessToken = accessToken;
                token.RefreshToken = refreshToken;
                token.ExpiresIn = (Convert.ToInt32(expireTime) * 60);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }

        }

        [Route("api/Refresh/")]
        [HttpPost]
        public IHttpActionResult Refresh(RefreshTokenRequest tokenRequest)
        {
            try
            {
                var secretKey = ConfigurationManager.AppSettings["TOK_SECRET_KEY"];
                var audienceToken = ConfigurationManager.AppSettings["TOK_AUDIENCE_TOKEN"];
                var issuerToken = ConfigurationManager.AppSettings["TOK_ISSUER_TOKEN"];
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

                SecurityToken securityToken;
                var tokenHandler = new JwtSecurityTokenHandler();
                TokenValidationParameters validationParameters = new TokenValidationParameters()
                {
                    ValidAudience = audienceToken,
                    ValidIssuer = issuerToken,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    LifetimeValidator = this.LifeTimeValidator,
                    IssuerSigningKey = securityKey
                };

                Thread.CurrentPrincipal = tokenHandler.ValidateToken(tokenRequest.refreshToken, validationParameters, out securityToken);

                var expireTime = ConfigurationManager.AppSettings["TOK_EXPIRE_MINUTES"];
                var accessToken = GenerateTokenJWT();
                var newRefreshToken = GenerateTokenJWT();
                Token token = new Token();
                token.AccessToken = accessToken;
                token.RefreshToken = newRefreshToken;
                token.ExpiresIn = (Convert.ToInt32(expireTime) * 60);
                return Ok(token);
            }
            catch (SecurityTokenValidationException)
            {
                return Unauthorized();
            }
            catch (Exception)
            {
                return InternalServerError();

            }
        }
               
        private string GenerateTokenJWT()
        {
            var now = DateTime.UtcNow;

            var secretKey = ConfigurationManager.AppSettings["TOK_SECRET_KEY"];
            var audienceToken = ConfigurationManager.AppSettings["TOK_AUDIENCE_TOKEN"];
            var issuerToken = ConfigurationManager.AppSettings["TOK_ISSUER_TOKEN"];
            var expireTime = ConfigurationManager.AppSettings["TOK_EXPIRE_MINUTES"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience:audienceToken,
                issuer: issuerToken,
                notBefore: now,
                expires: now.AddMinutes(Convert.ToInt32(expireTime)),
                signingCredentials: signingCredentials
                );

            var jwTokenString = tokenHandler.WriteToken(jwtSecurityToken);


            return jwTokenString;

        }

        public bool LifeTimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            if (expires != null)
            {
                if (DateTime.UtcNow < expires) return true;
            }
            return false;
        }

    }
}
