using Microsoft.EntityFrameworkCore;
using TemplateDotNet.Infra.Data.EF;
using TemplateDotNet.WebApi.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Iniciando a configura��o do banco de dados
builder.Services.AddDbContext<TemplateDotNetDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Iniciando a configura��o de inje��o de depend�ncia
builder.Services.AddRepositoryInjection();
builder.Services.AddUseCaseInjection();
builder.Services.AddServiceInjection();

// Iniciando a configura��o do JWT
builder.Services.AddJwtConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.MapControllers();

app.Run();
