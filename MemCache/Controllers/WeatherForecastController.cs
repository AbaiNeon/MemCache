using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MemCache.Controllers
{
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMemoryCache _memoryCache;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _memoryCache = memoryCache;
        }

        [HttpPost("SetCache")]
        public IActionResult SetCache()
        {
            _memoryCache.Set("key1", "value1");
            return Ok();
        }

        [HttpPost("GetCache")]
        public IActionResult GetCache(string key)
        {
            var found = _memoryCache.TryGetValue(key, out var value);
            return Ok(found ? value : "");
        }
    }
}
