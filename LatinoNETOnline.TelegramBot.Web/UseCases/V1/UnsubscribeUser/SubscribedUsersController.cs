using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.UseCases.Bots.Subscription.UnsubscribeUser;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LatinoNETOnline.TelegramBot.Web.UseCases.V1.UnsubscribeUser
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/SubscribedUser")]
    [ApiController]
    public class SubscribedUsersController : ControllerBase
    {
        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete([FromServices] IMediator mediator, [FromRoute] int userId)
        {
            UnsubscribeUserRequest unsubscribeUserRequest = new UnsubscribeUserRequest(userId, null);
            await mediator.Send(unsubscribeUserRequest);

            return Ok();
        }
    }
}
