using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Starwars.App.Auth.Code;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


var configuration = builder.Configuration;


builder.Services.AddSingleton<JwtTokenService>();

// Add JWT authentication
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
        };

        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = e =>
            {
                //_logger.Verbose($"[Auth] OnMessageReceived");
                return Task.CompletedTask;
            },
            OnTokenValidated = e =>
            {
                //_logger.Verbose($"[Auth] OnTokenValidated");
                return Task.CompletedTask;
            },
            OnAuthenticationFailed = e =>
            {
                //_logger.Error($"[Auth] OnAuthenticationFailed > {e.Exception.Message}");
                return Task.CompletedTask;
            },
            OnChallenge = e =>
            {
                //_logger.Verbose($"[Auth] OnChallenge");
                return Task.CompletedTask;
            }
        };
    });


builder.Services.AddScoped<IUserClaimsPrincipalFactory<IUsuario>, UsuarioClaimsPrincipalFactory>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
