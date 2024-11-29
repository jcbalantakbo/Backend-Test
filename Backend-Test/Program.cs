using Backend_Test.Application.Interfaces;
using Backend_Test.Application.Services;
using Backend_Test.Domain.Interfaces;
using Backend_Test.Infrastructure.Data;
using Backend_Test.Infrastructure.Middleware;
using Backend_Test.Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Backend_Test", Version = "v1" });
});


builder.Services.AddSingleton<Data>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();


builder.Services.AddScoped<IPersonService, PersonService>();

builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IPurchaseService, PurchaseService>();
builder.Services.AddScoped<ICsvService, PurchaseCsvService>();
builder.Services.AddSingleton<IExceptionHandler, GlobalExceptionHandler>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Backend_Test v1"));
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();


app.MapControllers();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();
