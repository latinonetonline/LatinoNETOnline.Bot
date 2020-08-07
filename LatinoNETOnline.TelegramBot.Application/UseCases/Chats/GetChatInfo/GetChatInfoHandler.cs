using System.Threading;
using System.Threading.Tasks;
using LatinoNETOnline.TelegramBot.Application.Services;
using MediatR;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.Chats.GetChatInfo
{
    public class GetChatInfoHandler : IRequestHandler<GetChatInfoRequest, GetChatInfoResult>
    {
        private readonly IBotMessageService _botMessageService;

        public GetChatInfoHandler(IBotMessageService botMessageService)
        {
            _botMessageService = botMessageService;
        }

        public async Task<GetChatInfoResult> Handle(GetChatInfoRequest request, CancellationToken cancellationToken)
        {
            var chat = await _botMessageService.GetChat(request.ChatId);

            return new GetChatInfoResult
            {
                ChatId = chat.ChatId,
                Title = chat.Title,
                IsGroup = chat.IsGroup
            };
        }
    }
}
