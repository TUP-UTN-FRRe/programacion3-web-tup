using FifaClubWorldCup.Core.Config;
using FifaClubWorldCup.Core.Datos;
using FifaClubWorldCup.Core.Negocio;

var builder = WebApplication.CreateBuilder(args);

//Read configuration files
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

var configuracionActual = new ConfiguracionActual();
//builder.Configuration.Bind(configuracionActual);
configuracionActual.FifaClubWorldCupConnectionString = builder.Configuration.GetConnectionString("FifaClubWorldCupConnectionString");

builder.Services.AddScoped<ConfiguracionActual>(provider => configuracionActual);

builder.Services.AddScoped<EquipoRepository>();
builder.Services.AddScoped<EquipoNegocio>();

// Add services to the container.
builder.Services.AddControllersWithViews();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
