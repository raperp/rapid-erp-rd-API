using FluentValidation;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using RapidERP.Application.Validator.CountryValidator;
using RapidERP.Infrastructure.Extentions;
using RapidERP.Infrastructure.Health;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddValidatorsFromAssemblyContaining<CountryPOSTRequestValidator>();
builder.Services.AddScopedServices();
builder.Services.AddHealthChecks().AddCheck<SqlHealth>("sql-health-check", HealthStatus.Unhealthy);
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();

app.UseSwaggerUI();

app.MapHealthChecks("health");

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
