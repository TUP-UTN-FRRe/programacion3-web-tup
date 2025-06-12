using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace Starwars.App.Auth.Code
{
    public class UsuarioClaimsPrincipalFactory : IUserClaimsPrincipalFactory<IUsuario>
    {
        private IdentityOptions _options;

        public UsuarioClaimsPrincipalFactory(IOptions<IdentityOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }

        public Task<ClaimsPrincipal> CreateAsync(IUsuario user)
        {
            var id = new ClaimsIdentity(
                IdentityConstants.ApplicationScheme, //_options.Cookies.ApplicationCookieAuthenticationScheme,
                _options.ClaimsIdentity.UserNameClaimType,
                _options.ClaimsIdentity.RoleClaimType);

            id.AddClaim(new Claim(_options.ClaimsIdentity.UserIdClaimType, user.UsuarioId.ToString()));
            id.AddClaim(new Claim(_options.ClaimsIdentity.UserNameClaimType, user.NombreUsuario));

            //// required by IdentityServer
            //id.AddClaim(new Claim(JwtClaimTypes.Name, user.NombreUsuario));
            //id.AddClaim(new Claim(JwtClaimTypes.Subject, user.UsuarioId.ToString()));
            //id.AddClaim(new Claim(JwtClaimTypes.IdentityProvider, IdentityConstants.ApplicationScheme)); //_options.Cookies.ApplicationCookieAuthenticationScheme
            //id.AddClaim(new Claim(JwtClaimTypes.AuthenticationTime, DateTimeOffset.UtcNow.ToString(), ClaimValueTypes.Integer));



            return Task.FromResult(new ClaimsPrincipal(id));
        }

    }
}