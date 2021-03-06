﻿using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Domain;

namespace LatinoNETOnline.TelegramBot.Application.Services
{
    public interface IGitHubService
    {
        Task<FileContent> GetFileContentAsync(long repositoryId, string path, string fileName);
    }
}
