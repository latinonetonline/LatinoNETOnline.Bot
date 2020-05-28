﻿namespace LatinoNETOnline.TelegramBot.Infrastructure.Options
{
    public class GitHubOptions
    {
        public long EventRepositoryId { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Branch { get; set; }
        public string Token { get; set; }
    }
}
