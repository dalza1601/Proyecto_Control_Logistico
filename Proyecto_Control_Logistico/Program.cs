using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Proyecto_Control_Logistico.Application.Interfaces.IRepository;
using Proyecto_Control_Logistico.Application.Mapping;
using Proyecto_Control_Logistico.Application.UseCase;
using Proyecto_Control_Logistico.Domain.Entities;
using Proyecto_Control_Logistico.FL.UTIL.Excel.Interfaces;
using Proyecto_Control_Logistico.FL.UTIL.Excel.Services;
using Proyecto_Control_Logistico.Infrastructure.Data;
using Proyecto_Control_Logistico.Infrastructure.Mongo;
using Proyecto_Control_Logistico.Infrastructure.Mongo.Mappings;
using Proyecto_Control_Logistico.Infrastructure.Mongo.Repositories;
using Proyecto_Control_Logistico.Infrastructure.Mongo.Repositories.Interfaces;
using Proyecto_Control_Logistico.Infrastructure.Repositories;
using Proyecto_Control_Logistico.Infrastructure.Repositories.Repository;
using Proyecto_Control_Logistico.Infrastructure.Seed;
using Proyecto_Control_Logistico.Infrastructure.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("SQLSERVER_CONECTION") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//Configuracion del Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();

builder.Services.AddControllersWithViews();


builder.Services.AddRazorPages();

//Configuracion MongoDB
MongoClassMap.RegisterMappings();
builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoSettings"));
builder.Services.AddSingleton<MongoDbContext>();
builder.Services.AddScoped<IMongoUnitOfWork, MongoUnitOfWork>();
builder.Services.AddScoped<IExcelService, ExcelService>();

// Agregamos los casos de uso de la capa Application
builder.Services.AddApplicationServices();

// Agregamos los repositorios de la capa Infrastructure
builder.Services.AddInfrastructureServices(builder.Configuration);

//Agregamos el orquestador que es UnitOfWork EF
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile(new MappingHelper());
});

// Registro de SignalIR biblioteca de código abierto de Microsoft para ASP.NET
// que facilita la incorporación de funciones en tiempo real en aplicaciones web
builder.Services.AddSignalR();

var app = builder.Build();

// Agregamos el orquestador de Seeders
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    DbInitializer.Initialize(db);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Admin}/{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
// url -> /Producto/Detalle/1
// url -> /Admin/Producto/Detalle/1

app.MapRazorPages()
   .WithStaticAssets();

// Configuración de SignalR para el hub de inventario (Mapeo del hub)
app.MapHub<InventoryHub>("/inventoryHub");

app.Run();
