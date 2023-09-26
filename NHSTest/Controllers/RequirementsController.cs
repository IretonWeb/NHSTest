using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NHSTest.Application.Command.Requirements;
using NHSTest.Application.Command.Staff;
using NHSTest.Application.Queries.Requirements;

namespace NHSTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequirementsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RequirementsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("save")]
        public async Task<IActionResult> SaveAsync([FromBody] AddRequirementCommand.Request request)
        {
            var result = await _mediator.Send(request);
            return new OkObjectResult(result);
        }

        [HttpGet("getAllRequirements")]
        public async Task<IActionResult> GetAllRequirementsAsync()
        {
            var result = await _mediator.Send(new GetAllRequirementsQuery());
            return new OkObjectResult(result);
        }

        [HttpGet("getRequirement")]
        public async Task<IActionResult> GetRequirementAsync([FromQuery] GetRequirementQuery query)
        {
            var result = await _mediator.Send(query);
            return new OkObjectResult(result);
        }

        [HttpGet("closeRequirement")]
        public async Task<IActionResult> GetCloseAsync([FromQuery] CloseRequirementCommand command)
        {
            var result = await _mediator.Send(command);
            return new OkObjectResult(result);
        }
    }
}
