using System.Threading.Tasks;
using LatinoNETOnline.TelegramBot.Application.UseCases.Chats.GetSubscribedChatsInfo;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LatinoNETOnline.TelegramBot.Web.UseCases.V1.GetSubscribedChats
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class GetSubscribedChatsInfoController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromServices] IMediator mediator)
        {
            GetSubscribedChatsInfoRequest request = new GetSubscribedChatsInfoRequest();
            var response = await mediator.Send(request);

            return Ok(response);
        }
    }
}
