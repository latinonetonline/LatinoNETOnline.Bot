using System.Threading.Tasks;
using LatinoNETOnline.TelegramBot.Application.UseCases.Chats.GetChatInfo;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LatinoNETOnline.TelegramBot.Web.UseCases.V1.GetChatInfo
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class GetChatInfoController : ControllerBase
    {
        [HttpGet("{chatId}")]
        public async Task<IActionResult> Get([FromServices] IMediator mediator, long chatId)
        {
            GetChatInfoRequest request = new GetChatInfoRequest(chatId);
            var response = await mediator.Send(request);

            return Ok(response);
        }
    }
}
