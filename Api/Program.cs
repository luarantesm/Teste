using Api.Configuration;
using Application;
using Application.Interfaces;
using Domain.Interfaces;
using Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ContextAtivo>(options =>
              options.UseSqlServer(
                  builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.ResolveDependencies();
builder.Services.ResolveAutoMapper();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ativo.API", Version = "v1" });
});

builder.Services.AddHttpClient<IApplicationYahoo, ApplicationYahoo>(client =>
{
    client.BaseAddress = new Uri("https://query2.finance.yahoo.com/v8/finance/");
});

var app = builder.Build();

app.Use(async (context, next) =>
{
    await next.Invoke();
    var unitOfWork = (IUnitOfWork)context.RequestServices.GetService(typeof(IUnitOfWork));
    unitOfWork.Commit();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ativo.Api v1"));

    app.UseHttpsRedirection();

    app.UseCors(x => x.AllowAnyHeader()
                      .AllowAnyOrigin()
                      .AllowAnyMethod());
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();