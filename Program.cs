using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Microsoft.AspNetCore.Localization;    

var builder = WebApplication.CreateBuilder(args);

// 1. REGISTRO DE SERVICIOS (Servicios que usa la app)

// Configuración de la base de datos de Neon
var connectionString = builder.Configuration.GetConnectionString("NeonConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// Agregar controladores y vistas (MVC)
builder.Services.AddControllersWithViews();

// Configurar Autenticación y Autorización
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Home/Index";
    });

builder.Services.AddAuthorization();
//Servicios del historial
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<Pagin_Web_Zoonosis.Services.HistorialService>();


// 2. CONSTRUCCIÓN DE LA APLICACIÓN (Solo una vez)
var app = builder.Build();


// 3. CONFIGURACIÓN DEL PIPELINE HTTP (Middlewares)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(CultureInfo.InvariantCulture),
    SupportedCultures = new[] { CultureInfo.InvariantCulture },
    SupportedUICultures = new[] { CultureInfo.InvariantCulture }
});
app.UseRouting();

// Orden crucial: Autenticación SIEMPRE antes de Autorización
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();