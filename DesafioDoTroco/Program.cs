using DesafioDoTroco.Application;
using DesafioDoTroco.Application.Services.Implementations.Sales;
using DesafioDoTroco.Application.Services.Interfaces;
using DesafioDoTroco.Core;
using DesafioDoTroco.Core.Payments.Cash;
using DesafioDoTroco.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<DesafioDoTrocoDbContext>();

// Adicionar as dependências das Camadas
builder.Services.AddDependencysCore()
                .AddDependencysApplication();

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
