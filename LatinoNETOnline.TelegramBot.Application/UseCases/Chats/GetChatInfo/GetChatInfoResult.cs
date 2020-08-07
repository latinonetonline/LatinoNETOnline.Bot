namespace LatinoNETOnline.TelegramBot.Application.UseCases.Chats.GetChatInfo
{
    public class GetChatInfoResult
    {
        public bool Exist { get; set; }
        public long ChatId { get; set; }
        public string Title { get; set; }
        public bool IsGroup { get; set; }
    }
}
