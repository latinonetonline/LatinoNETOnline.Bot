using MediatR;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.Chats.GetChatInfo
{
    public class GetChatInfoRequest : IRequest<GetChatInfoResult>
    {
        public long ChatId { get; }

        public GetChatInfoRequest(long chatId)
        {
            ChatId = chatId;
        }
    }
}
