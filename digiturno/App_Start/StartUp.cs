using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security.Jwt;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Xml.Linq;


[assembly: OwinStartup(typeof(digiturno.App_Start.StartUp))]
namespace digiturno.App_Start
{
    public class StartUp
    {
        public void Configuration(IAppBuilder app) {
            var keystring= ConfigurationManager.AppSettings["JWT_SECREDT_KEY"].ToString();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keystring)).ToString();
            var issuer= ConfigurationManager.AppSettings["JWT_SECREDT_IUSSER"].ToString();
            var audience = ConfigurationManager.AppSettings["JWT_SECREDT_AUDIENCE"].ToString();
            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                }
            });
        }
    }
}