namespace LatinoNETOnline.TelegramBot.Application.UseCases.Messages.SendNextEventImage
{
    public class SendNextEventImageResponse
    {
        public SendNextEventImageResponse(int messageId)
        {
            MessageId = messageId;
        }

        public int MessageId { get; }
    }
}
