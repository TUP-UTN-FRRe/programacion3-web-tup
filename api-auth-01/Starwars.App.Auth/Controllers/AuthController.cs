using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Starwars.App.Auth.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace Starwars.App.Auth.Controllers { 

[ApiController]
[Route("api/[controller]")]
public class AuthController : Controller
{
    private readonly JwtTokenService _jwtTokenService;

    public AuthController(JwtTokenService jwtTokenService)
    {
        _jwtTokenService = jwtTokenService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {

        var isValid = CredentialsValidator(request);

        if (!isValid) { 
              return Unauthorized();
        }
      

        var claims = new List<Claim>
        {
            //new Claim(ClaimTypes.NameIdentifier, "1"),
            new Claim(ClaimTypes.Name, request.Username.ToLower()),
            // Add other claims as needed
        };

        var token = _jwtTokenService.GenerateToken(claims);
        return Ok(new { token });
    }


        [HttpPost("token")]
        [AllowAnonymous]
        public async Task<IActionResult> Token([FromBody] ClientCredentialsRequest request)
        {
            if (request is null)
            {
                return BadRequest(new { error = "" });
            }

            if (!string.Equals(request.grant_type, "client_credentials", StringComparison.OrdinalIgnoreCase))
                return BadRequest(new { error = "unsupported_grant_type" });


            var isValid = CredentialsValidator(request.client_id, request.client_secret);

            if (!isValid)
            {
                return Unauthorized(new { error = "invalid_client" });
            }

            var claims = new List<Claim>
        {
            new Claim("client_id", request.client_id),
            //new Claim("scope", request.scope ?? string.Empty)
        };

            var token = _jwtTokenService.GenerateToken(claims);

            return Ok(new
            {
                access_token = token,
                token_type = "Bearer",
                expires_in = 3600 //TODO: Set appropriate expiration time
            });
        }


    //    [HttpPost("token")]
    //[Consumes("application/x-www-form-urlencoded")]
    //[AllowAnonymous]
    //public async Task<IActionResult> Token([FromForm] ClientCredentialsRequest request)
    //{
    //    if (!string.Equals(request.grant_type, "client_credentials", StringComparison.OrdinalIgnoreCase))
    //        return BadRequest(new { error = "unsupported_grant_type" });


    //    var isValid = CredentialsValidator(request.client_id, request.client_secret);

    //    if (!isValid)
    //    {
    //        return Unauthorized(new { error = "invalid_client" });
    //    }

    //    var claims = new List<Claim>
    //    {
    //        new Claim("client_id", request.client_id),
    //        new Claim("scope", request.scope ?? string.Empty)
    //    };

    //    var token = _jwtTokenService.GenerateToken(claims);

    //    return Ok(new
    //    {
    //        access_token = token,
    //        token_type = "Bearer",
    //        expires_in = 3600 //TODO: Set appropriate expiration time
    //    });
    //}

   


    private bool CredentialsValidator(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            return false;
        }

        if (username.Length <= 8)
        {
            return false;
        }

        var reversedUsername = new string(username.Reverse().ToArray());

        if (reversedUsername != password)
        {
            return false;
        }

        return true;
    }



    private bool CredentialsValidator(LoginRequest request)
    {
        if (request is null)
        {
            return false;
        }
       
       return CredentialsValidator(request.Username, request.Password);
    }


}

public class LoginRequest
{
    //TODO: To Entities
    public string Username { get; set; }
    public string Password { get; set; }
}


public class ClientCredentialsRequest
{
    public string grant_type { get; set; }
    public string client_id { get; set; }
    public string client_secret { get; set; }
    ///|public string scope { get; set; }
    //public bool? RequireClientSecret { get; set; }
}
}
