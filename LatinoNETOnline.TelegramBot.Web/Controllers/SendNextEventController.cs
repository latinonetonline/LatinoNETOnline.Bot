using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.UseCases.Bots.Messages.SendNextEvent;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace LatinoNETOnline.TelegramBot.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendNextEventController : BaseController
    {
        public SendNextEventController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            SendNextEventRequest request = new SendNextEventRequest(986536895, null);
            await Mediator.Send(request);

            return Ok();
        }
    }
}
