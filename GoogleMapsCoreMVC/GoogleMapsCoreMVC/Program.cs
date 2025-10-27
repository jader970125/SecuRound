using Microsoft.EntityFrameworkCore;
using GoogleMapsCoreMVC.Models;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Conexión a la BD
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔹 Habilitar controladores con vistas
builder.Services.AddControllersWithViews();

// 🔹 Registrar sesiones (antes del Build)
builder.Services.AddSession();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// 🔹 Configurar el pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 🔹 Activar sesiones (DEBE ir ANTES de UseAuthorization)
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
