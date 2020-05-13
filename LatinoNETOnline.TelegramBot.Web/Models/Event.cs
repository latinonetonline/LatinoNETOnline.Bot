using System;

namespace LatinoNETOnline.TelegramBot.Services.Models
{
    public class Event
    {
        public Guid Guid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string ImageUrl { get; set; }
        public string Speaker { get; set; }
        public string GitHubUsername { get; set; }
        public bool IsDraft { get; set; }
    }
}
