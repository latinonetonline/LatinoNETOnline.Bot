using System.Threading;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.Services;

using MediatR;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.Bots.Messages.SendNextEventImage
{
    public class SendNextEventImageHandler : IRequestHandler<SendNextEventImageRequest, SendNextEventImageResponse>
    {
        private readonly IBotMessageService _botMessageService;
        public SendNextEventImageHandler(IBotMessageService botMessageService)
        {
            _botMessageService = botMessageService;
        }

        public async Task<SendNextEventImageResponse> Handle(SendNextEventImageRequest request, CancellationToken cancellationToken)
        {
            int messageId = await _botMessageService.SendImage(request.ImageUri, request.ChatId, request.ReplyToMessageId);

            return new SendNextEventImageResponse(messageId);
        }
    }
}
