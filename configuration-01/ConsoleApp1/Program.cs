// See https://aka.ms/new-console-template for more information


using ConsoleApp1;
using Microsoft.Extensions.Configuration;

//https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration
IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddUserSecrets<Program>()
    .Build();

//https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets


//var title = "Programacion III";
var title = configuration["Title"];

//Option 1
//var emailSection = configuration.GetSection("Email");
//var emailServer = emailSection["Server"];
//var emailPort = emailSection["Port"];

//Option 2
//var emailServer = configuration["Email:Server"];
//var emailPort = configuration["Email:Port"];

//Option 3
var emailConfig = configuration.GetSection("Email").Get<EmailConfig>();

var emailServer = emailConfig.Server;
var emailPort = emailConfig.Port;




Console.WriteLine($"Hello, {title}! The email server is {emailServer} on port {emailPort}.");
