using System;
using System.Threading.Tasks;
using LatinoNETOnline.TelegramBot.Domain.Dto;

namespace LatinoNETOnline.TelegramBot.Application.Services
{
    public interface IBotMessageService
    {
        Task<int> SendImage(Uri imageUri, long chatId, int? replyToMessageId);
        Task<int> SendText(string messageText, long chatId, int? replyToMessageId);
        Task<ChatDto> GetChat(long chatId);
    }
}
