using DesafioDoTroco.Application;
using DesafioDoTroco.Application.Services.Implementations.Sales;
using DesafioDoTroco.Application.Services.Interfaces;
using DesafioDoTroco.Core;
using DesafioDoTroco.Core.Payments.Cash;
using DesafioDoTroco.Core.Payments.Interfaces;
using DesafioDoTroco.Core.Services.Implementations.Sales;
using DesafioDoTroco.Core.Services.Interfaces.Sales;
using DesafioDoTroco.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Padrão de Projeto
builder.Services.AddSingleton<DesafioDoTrocoDbContext>();

// Adicionar as dependências das Camadas
// Cada Biblioteca é responsável por adicionar as dependências internas
builder.Services.AddDependencysApplication();

// Camada Core
builder.Services.AddScoped<ICash, ChangeCalculator>();
builder.Services.AddScoped<ICashManager, CashManager>();

// liberar acesso ao projeto do React
// verificar o link externo do React e alterar aqui, caso necessário
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy",
        policy =>
        {
            policy
                .WithOrigins("http://localhost:5173")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("ReactPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
