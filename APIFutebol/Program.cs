global using APIFutebol.Data;
global using Microsoft.EntityFrameworkCore;
using APIFutebol.Data.Dtos;
using APIFutebol.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Adicionando o contexto para que seja inicializado a conex�o entre aplica��o e banco de dados
builder.Services.AddDbContext<FutebolContext>(options =>
{
    options.UseLazyLoadingProxies()
    .UseSqlServer(builder.Configuration.GetConnectionString("FutebolConnection"));
});

builder.Services.AddScoped<ArbitragemService, ArbitragemService>();
builder.Services.AddScoped<ConfrontoService, ConfrontoService>();
builder.Services.AddScoped<LocalizacaoService, LocalizacaoService>();
builder.Services.AddScoped<ResultadoService, ResultadoService>();

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
