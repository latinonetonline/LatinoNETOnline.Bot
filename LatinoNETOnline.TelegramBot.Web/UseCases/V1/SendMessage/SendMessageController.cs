using System;
using System.Threading.Tasks;
using LatinoNETOnline.TelegramBot.Application.UseCases.SendMessage;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LatinoNETOnline.TelegramBot.Web.UseCases.V1.SendMessage
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> SendMessage([FromServices] IMediator mediator, [FromBody] SendMessageBodyRequest bodyRequest)
        {
            Uri imageUri = string.IsNullOrWhiteSpace(bodyRequest.ImageLink) ? null : new Uri(bodyRequest.ImageLink);

            SendMessageRequest request = new SendMessageRequest(bodyRequest.Message, imageUri, bodyRequest.Chats);

            var response = await mediator.Send(request);

            return Ok(response);
        }
    }
}
