using Microsoft.EntityFrameworkCore;
using GoogleMapsCoreMVC; // ✅ Usa el namespace correcto (donde está ApplicationDbContext)
using GoogleMapsCoreMVC.Models;

var builder = WebApplication.CreateBuilder(args);

// 🔹 1. Configurar la conexión a la base de datos (usa la cadena del appsettings.json)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔹 2. Habilitar controladores con vistas (MVC)
builder.Services.AddControllersWithViews();

// 🔹 3. Registrar soporte para sesiones (para mantener el usuario logueado, etc.)
builder.Services.AddSession();

// 🔹 4. Registrar HttpContextAccessor (para acceder al contexto en filtros, controladores, etc.)
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// 🔹 5. Configurar el pipeline de la aplicación
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 🔹 6. Activar sesiones (debe ir antes de UseAuthorization)
app.UseSession();

app.UseAuthorization();

// 🔹 7. Rutas del sistema
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
