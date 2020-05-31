using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.UseCases.Announcements.AnnouncementHourLeft;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LatinoNETOnline.TelegramBot.Web.UseCases.V1.AnnouncementHourLeftNextEvent
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {
        [HttpPost("HourLeft")]
        public async Task<IActionResult> Post([FromServices] IMediator mediator)
        {
            AnnouncementHourLeftRequest request = new AnnouncementHourLeftRequest();
            await mediator.Send(request);

            return Ok();
        }
    }
}
