using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PRFTLatam.Workshop.Services.Logic;
using System.Linq;

namespace PRFTLatam.Workshop.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class WebAPI : ControllerBase
    {
        private readonly ILogger<WebAPI> _logger;

        public WebAPI(ILogger<WebAPI> logger)
        {
            _logger = logger;
        }

        [HttpGet("HealthCheck")]
        public ActionResult HealthCheckController()
        {
            return Ok();
        }

        [HttpGet("IdValidation")]
        public ActionResult IdValidationControl(string id)
        {
            var errors = Validations.IdValidator(id);
            if (errors.Any())
            {
                return this.UnprocessableEntity(errors);
            }

            return Ok();
        }
    }
}
