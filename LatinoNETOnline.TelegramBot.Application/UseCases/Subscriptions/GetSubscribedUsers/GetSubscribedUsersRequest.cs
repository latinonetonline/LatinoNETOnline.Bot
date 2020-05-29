using System;
using System.Collections.Generic;
using System.Text;

using MediatR;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.Subscriptions.GetSubscribedUsers
{
    public class GetSubscribedUsersRequest : IRequest<GetSubscribedUsersResponse>
    {
    }
}
