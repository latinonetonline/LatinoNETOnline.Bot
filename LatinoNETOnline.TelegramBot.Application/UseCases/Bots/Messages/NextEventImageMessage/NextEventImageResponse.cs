namespace LatinoNETOnline.TelegramBot.Application.UseCases.Bots.Messages.NextEventImageMessage
{
    public class NextEventImageResponse
    {
        public NextEventImageResponse(int messageId)
        {
            MessageId = messageId;
        }

        public int MessageId { get; }
    }
}
