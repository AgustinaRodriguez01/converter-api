using converter_api.Resource;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace converter_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConverterController : ControllerBase
    {
        [HttpGet(Name = "GetQuote")]
        public async Task<string> GetQuote([FromQuery, Required] decimal value)
        {
            DolarAPI api = new DolarAPI();
            decimal result = await api.GetSpecificQuote();
            return (result * value).ToString();
        }
    }
}
