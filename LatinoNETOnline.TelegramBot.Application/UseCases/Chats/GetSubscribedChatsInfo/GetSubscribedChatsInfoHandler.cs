using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LatinoNETOnline.TelegramBot.Application.Repositories;
using LatinoNETOnline.TelegramBot.Application.Services;
using LatinoNETOnline.TelegramBot.Domain.Dto;
using MediatR;

namespace LatinoNETOnline.TelegramBot.Application.UseCases.Chats.GetSubscribedChatsInfo
{
    public class GetSubscribedChatsInfoHandler : IRequestHandler<GetSubscribedChatsInfoRequest, GetSubscribedChatsInfoResult>
    {
        private readonly ISubscribedChatRepository _subscribedChatRepository;
        private readonly IBotMessageService _botMessageService;

        public GetSubscribedChatsInfoHandler(ISubscribedChatRepository subscribedChatRepository, IBotMessageService botMessageService)
        {
            _subscribedChatRepository = subscribedChatRepository;
            _botMessageService = botMessageService;
        }

        public async Task<GetSubscribedChatsInfoResult> Handle(GetSubscribedChatsInfoRequest request, CancellationToken cancellationToken)
        {
            List<ChatDto> chatDtos = new List<ChatDto>();
            var subscribedChats = await _subscribedChatRepository.GetAll();

            List<Task> tasks = new List<Task>();

            foreach (var subscribedChat in subscribedChats)
            {
                var chatTask = _botMessageService.GetChat(subscribedChat.ChatId);
                await chatTask.ContinueWith((chat) =>
                {
                    if (chat.Result != null)
                        chatDtos.Add(chat.Result);
                    
                });

                tasks.Add(chatTask);
            }

            Task.WaitAll(tasks.ToArray());

            return new GetSubscribedChatsInfoResult
            {
                Chats = chatDtos
            };
        }
    }
}
