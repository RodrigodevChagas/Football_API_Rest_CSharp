global using APIFutebol.Data;
global using Microsoft.EntityFrameworkCore;
using APIFutebol.Data.Dtos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Adicionando o contexto para que seja inicializado a conexão entre aplicação e banco de dados
builder.Services.AddDbContext<FutebolContext>(options =>
{
    options.UseLazyLoadingProxies()
    .UseSqlServer(builder.Configuration.GetConnectionString("FutebolConnection"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
