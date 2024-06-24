using Services.CasheService.Interface;
using StackExchange.Redis;
using System.Text.Json;

namespace Services.CasheService.Service
{
    public class CasheService : ICasheService
    {
        private readonly IDatabase _dataBase;
        public CasheService(IConnectionMultiplexer redis) 
        {
            _dataBase = redis.GetDatabase();

        }
        public async Task<string> SetCasheResponseAsync(string cashKey, object response, TimeSpan timeToLive)
        {
            if (response is null)
                return null;

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            var serializedResponse = JsonSerializer.Serialize(response, options);

            await _dataBase.StringSetAsync(cashKey, serializedResponse, timeToLive);

            return await GetCasheResponseAsync(cashKey);

        }

        public async Task<string> GetCasheResponseAsync(string cashKey)
        {
            var cashedResponse = await _dataBase.StringGetAsync(cashKey);

            if (cashedResponse.IsNullOrEmpty)
                return null;
            
            return cashedResponse;
        }

    }
}
