using MagicOnion;
using MagicOnion.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MiniService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddMagicOnion();
builder.Services.AddScoped<IMyFirstService, MyFirstService>();

builder.Services.AddCors(options => options.AddPolicy("default", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

await using var app = builder.Build();

app.UseCors("default");
app.UseGrpcWeb();

app.MapMagicOnionService().EnableGrpcWeb();

await app.RunAsync();