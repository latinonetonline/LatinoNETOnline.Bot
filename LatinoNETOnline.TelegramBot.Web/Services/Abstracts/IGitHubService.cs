using System.Threading.Tasks;

using LatinoNETOnline.TelegramBot.Services.Models;

namespace LatinoNETOnline.TelegramBot.Services.Abstracts
{
    public interface IGitHubService
    {
        Task<FileContent> GetFileContentAsync(long repositoryId, string path, string fileName);
    }
}
