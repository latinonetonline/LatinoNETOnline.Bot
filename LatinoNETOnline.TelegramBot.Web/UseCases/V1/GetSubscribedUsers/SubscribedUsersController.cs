using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.UseCases.Subscriptions.GetSubscribedChats;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LatinoNETOnline.TelegramBot.Web.UseCases.V1.GetSubscribedUsers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/SubscribedUser")]
    [ApiController]
    public sealed class SubscribedUsersController : ControllerBase
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
