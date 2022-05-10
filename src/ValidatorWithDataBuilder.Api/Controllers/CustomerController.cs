using Microsoft.AspNetCore.Mvc;
using ValidatorWithDataBuilder.Domain.CustomerAggregate;
using ValidatorWithDataBuilder.Domain.CustomerAggregate.Exceptions;

namespace ValidatorWithDataBuilder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public ActionResult<Task> CreateCustomer([FromBody] Customer customer)
        {
            try
            {
                return NoContent();
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
