using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;


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

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();

app.Run();
