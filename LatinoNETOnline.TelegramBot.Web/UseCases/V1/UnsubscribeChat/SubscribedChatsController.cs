using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.UseCases.Subscriptions.UnsubscribeChat;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LatinoNETOnline.TelegramBot.Web.UseCases.V1.UnsubscribeChat
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class SubscribedChatsController : ControllerBase
    {
        [HttpDelete("{chatId}")]
        public async Task<IActionResult> Delete([FromServices] IMediator mediator, [FromRoute] long chatId)
        {
            UnsubscribeChatRequest unsubscribeChatRequest = new UnsubscribeChatRequest(chatId);
            await mediator.Send(unsubscribeChatRequest);

            return Ok();
        }
    }
}
