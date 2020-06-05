using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.UseCases.Subscriptions.SubscribeUser;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LatinoNETOnline.TelegramBot.Web.UseCases.V1.CreateSubscribeUser
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/SubscribedUser")]
    [ApiController]
    public class SubscribedUsersController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromServices] IMediator mediator, [FromBody] CreateSubscribedUserRequest request)
        {
            SubscribeUserRequest subscribeUserRequest = new SubscribeUserRequest(request.UserId, string.Empty, null);
            await mediator.Send(subscribeUserRequest);

            return Ok();
        }
    }
}
