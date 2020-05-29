using System.Threading;
using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Application.Bots;

using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.Bots.Messages.NextEventImageMessage
{
    public class NextEventImageHandler : BotMessageHandlerBase<NextEventImageRequest, NextEventImageResponse>
    {
        public NextEventImageHandler(IBotManager<LatinoNetOnlineTelegramBot> botManager) : base(botManager)
        { }

        public override async Task<NextEventImageResponse> Handle(NextEventImageRequest request, CancellationToken cancellationToken)
        {
            Message msg = await Bot.Client.SendPhotoAsync(
                request.ChatId,
                new FileToSend(request.ImageUri),
                replyToMessageId: request.ReplyToMessageId.GetValueOrDefault());

            return new NextEventImageResponse(msg.MessageId);
        }
    }
}
