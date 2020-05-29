using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.UseCases.Subscriptions.GetSubscribedUsers;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace LatinoNETOnline.TelegramBot.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribedUsersController : BaseController
    {
        public SubscribedUsersController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetSubscribedUsersRequest request = new GetSubscribedUsersRequest();
            var response = await Mediator.Send(request);

            return Ok(response);
        }
    }
}
