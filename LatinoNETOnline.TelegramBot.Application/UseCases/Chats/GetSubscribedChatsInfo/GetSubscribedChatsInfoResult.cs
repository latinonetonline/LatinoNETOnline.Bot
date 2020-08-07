using System.Collections.Generic;
using LatinoNETOnline.TelegramBot.Domain.Dto;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.Chats.GetSubscribedChatsInfo
{
    public class GetSubscribedChatsInfoResult
    {
        public IEnumerable<ChatDto> Chats { get; set; }
    }
}
