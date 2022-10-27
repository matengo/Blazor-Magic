using MagicOnion;
using MagicOnion.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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

public class MyFirstService : ServiceBase<IMyFirstService>, IMyFirstService
{
    private readonly ILogger<MyFirstService> _logger;
    public MyFirstService(ILogger<MyFirstService> logger)
    {
        _logger = logger;
    }
    public async UnaryResult<int> SumAsync(int x, int y)
    {
        _logger.LogInformation("We are doing a mini grpc service");

        return x + y;
    }
}
