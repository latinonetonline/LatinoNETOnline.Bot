using System;
using System.Threading.Tasks;

namespace LatinoNETOnline.TelegramBot.Application.Services
{
    public interface IBotMessageService
    {
        Task<int> SendImage(Uri imageUri, long chatId, int? replyToMessageId);
        Task<int> SendText(string messageText, long chatId, int? replyToMessageId);
    }
}
