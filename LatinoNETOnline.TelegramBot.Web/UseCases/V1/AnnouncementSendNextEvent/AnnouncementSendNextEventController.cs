using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.UseCases.Announcements.AnnouncementNextEvent;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LatinoNETOnline.TelegramBot.Web.UseCases.V1.AnnouncementSendNextEvent
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Announcement")]
    [ApiController]
    public class AnnouncementSendNextEventController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromServices] IMediator mediator)
        {
            AnnouncementNextEventRequest request = new AnnouncementNextEventRequest();
            await mediator.Send(request);

            return Ok();
        }
    }
}
