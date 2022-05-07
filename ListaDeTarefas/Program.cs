using ListaDeTarefas.Business;
using ListaDeTarefas.Business.Interface;
using ListaDeTarefas.Context;
using ListaDeTarefas.Models;
using ListaDeTarefas.Repository;
using ListaDeTarefas.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connection = string.Empty;
//connection = "DefaultConnection";
connection = "AvanadeConnection";
//connection = "ProdConnection";
builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString(connection)));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
});

RegistrarRepository(builder.Services);
RegistrarBusiness(builder.Services);
builder.Services.AddControllers();

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

//void ConfigureServices(IServiceCollection services)
//{
//    services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
//    //services.AddTransient<IAnoRepository, AnoRepository>();
//    //services.AddTransient<IUsuarioRepository, UsuarioRepository>();
//    //services.AddTransient<ILoginSessionRepository, LoginSessionRepository>();
//    //services.AddTransient<ITurmaRepository, TurmaRepository>();
//    //services.AddTransient<IAlunoRepository, AlunoRepository>();
//    //services.AddTransient<INotaRepository, NotaRepository>();
//    //services.AddTransient<IComentarioAlunoRepository, ComentarioAlunoRepository>();
//    //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//    //services.AddScoped(sp => Login.GetLogin(sp));

//    //services.AddControllersWithViews();

//    //services.AddMemoryCache();
//    //services.AddSession();
//}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();

//void ConfigurandoSession(IServiceCollection servico)
//{
//    servico.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//    servico.AddMemoryCache();
//    servico.AddSession();
//}

void RegistrarRepository(IServiceCollection servico)
{
    servico.AddTransient<IUsuarioRepository, UsuarioRepository>();
    servico.AddTransient<ITarefaRepository, TarefaRepository>();
}

void RegistrarBusiness(IServiceCollection servico)
{
    servico.AddTransient<IUsuarioBusiness, UsuarioBusiness>();
    servico.AddTransient<ITarefaBusiness, TarefaBusiness>();
}