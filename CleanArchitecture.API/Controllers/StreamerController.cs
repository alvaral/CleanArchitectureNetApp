using System.Net;
using CleanArchitecture.Application.Features.Streamers.Commands.CreateStreamer;
using CleanArchitecture.Application.Features.Streamers.Commands.DeleteStreamer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StreamerController : ControllerBase
    {
        private IMediator _mediator;

        public StreamerController(IMediator mediator)
        {
            _mediator = mediator;   
        }

        [HttpPost(Name ="CreateStreamer")]
        [ProducesResponseType( (int) HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateStreamer([FromBody] CreateStreamerCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPost(Name = "UpdateStreamer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateStreamer([FromBody] CreateStreamerCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteStreamer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteStreamer(int id)
        {
            var command = new DeleteStreamerCommand
            {
                Id = id
            };

            return NoContent();
        }
    }
}
