using MagicOnion.Server;
using MagicOnion;
using Microsoft.Extensions.Logging;

namespace MiniService.Services
{
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
}
