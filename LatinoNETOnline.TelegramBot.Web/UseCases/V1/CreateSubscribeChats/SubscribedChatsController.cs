using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.UseCases.Subscriptions.SubscribeChat;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LatinoNETOnline.TelegramBot.Web.UseCases.V1.CreateSubscribeChats
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class SubscribedChatsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromServices] IMediator mediator, [FromBody] CreateSubscribedChatRequest request)
        {
            SubscribeChatRequest subscribeChatRequest = new SubscribeChatRequest(request.ChatId);
            await mediator.Send(subscribeChatRequest);

            return Ok();
        }
    }
}
