using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.UseCases.Subscriptions.GetSubscribedChats;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LatinoNETOnline.TelegramBot.Web.UseCases.V1.GetSubscribedChats
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class SubscribedChatsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] IMediator mediator)
        {
            GetSubscribedChatsRequest request = new GetSubscribedChatsRequest();
            var response = await mediator.Send(request);

            return Ok(response);
        }
    }
}
