using MediatR;

using Microsoft.AspNetCore.Mvc;
using NHSTest.Application.Command.Staff;
using NHSTest.Application.Queries.Requirements;
using NHSTest.Application.Queries.Staff;

namespace NHSTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StaffController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("save")]
        public async Task<IActionResult> Save([FromBody] AddStaffMemberCommand.Request request)
        {
            var result = await  _mediator.Send(request);
            return new OkObjectResult(result);
        }


        [HttpGet("getAllStaff")]
        public async Task<IActionResult> GetAllStaffAsync()
        {
            var result = await _mediator.Send(new GetAllStaffQuery());
            return new OkObjectResult(result);
        }

    }
}
