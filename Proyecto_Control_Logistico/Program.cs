using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Proyecto_Control_Logistico.Application.Mapping;
using Proyecto_Control_Logistico.Domain.Entities;
using Proyecto_Control_Logistico.FL.UTIL.Excel.Interfaces;
using Proyecto_Control_Logistico.FL.UTIL.Excel.Services;
using Proyecto_Control_Logistico.Infrastructure.Data;
using Proyecto_Control_Logistico.Infrastructure.Mongo;
using Proyecto_Control_Logistico.Infrastructure.Mongo.Mappings;
using Proyecto_Control_Logistico.Infrastructure.Mongo.Repositories;
using Proyecto_Control_Logistico.Infrastructure.Mongo.Repositories.Interfaces;
using Proyecto_Control_Logistico.Infrastructure.Repositories.IRepository;
using Proyecto_Control_Logistico.Infrastructure.Repositories.Repository;

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

//Agregamos el orquestador que es UnitOfWork EF
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile(new MappingHelper());
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;  
});

var app = builder.Build();

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
app.UseSession();
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

app.Run();
