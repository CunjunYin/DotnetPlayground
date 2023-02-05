using OpenIdConnectProvider.Core.DB;
using OpenIdConnectProvider.Core.Services;
using Microsoft.EntityFrameworkCore;
using OpenIdConnectProvider;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EFCoreInMemoryDb>(o => o.UseInMemoryDatabase("IDPDB"));
builder.Services.AddTransient<IClientValidator, ClientValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

InitializeDB.Initialize(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
