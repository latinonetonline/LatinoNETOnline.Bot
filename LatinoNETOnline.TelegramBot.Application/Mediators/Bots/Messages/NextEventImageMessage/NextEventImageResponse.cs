namespace LatinoNETOnline.TelegramBot.Application.Mediators.Bots.Messages.NextEventImageMessage
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
