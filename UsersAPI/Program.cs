using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UsersAPI.Data;
using UsersAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<UserDbContext>(options =>
{

    options.UseSqlServer(builder.Configuration.GetConnectionString("UsuarioConnection"));
});
builder.Services.AddIdentity<IdentityUser<int>, IdentityRole<int>>(opt =>

    opt.SignIn.RequireConfirmedEmail = true
    )
     .AddEntityFrameworkStores<UserDbContext>()
     .AddDefaultTokenProviders();

builder.Services.AddScoped<CadastroService, CadastroService>();
builder.Services.AddScoped<LoginService, LoginService>();
builder.Services.AddScoped<TokenService, TokenService>();
builder.Services.AddScoped<LogoutService, LogoutService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

 //Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
