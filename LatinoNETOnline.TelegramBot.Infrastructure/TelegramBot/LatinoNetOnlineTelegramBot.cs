using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Telegram.Bot.Framework;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace LatinoNETOnline.TelegramBot.Infrastructure.TelegramBot
{
    public class LatinoNetOnlineTelegramBot : BotBase<LatinoNetOnlineTelegramBot>
    {
        private readonly ILogger<LatinoNetOnlineTelegramBot> _logger;

        public LatinoNetOnlineTelegramBot(IOptions<BotOptions<LatinoNetOnlineTelegramBot>> botOptions, ILogger<LatinoNetOnlineTelegramBot> logger)
            : base(botOptions)
        {
            _logger = logger;
        }

        public override async Task HandleUnknownUpdate(Update update)
        {
            _logger.LogWarning("Unable to handle an update");

            const string unknownUpdateText = "Sorry! I don't know what to do with this message";

            if (update.Type == UpdateType.MessageUpdate)
            {
                await Client.SendTextMessageAsync(update.Message.Chat.Id,
                    unknownUpdateText,
                    replyToMessageId: update.Message.MessageId);
            }
            else
            {
                if (update.CallbackQuery.Data == "sobrenosotros")
                {
                    await Client.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id,
                    "Seleccionaste Sobre Nosotros");
                }
                else if (update.CallbackQuery.Data == "nuestrasredes")
                {
                    await Client.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id,
                    "Seleccionaste Nuestras Redes");
                }
                else if (update.CallbackQuery.Data == "siguienteevento")
                {
                    await Client.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id,
                    "Seleccionaste Siguiente Evento");
                }

                if (update.Message.NewChatMembers.Length > 0)
                {
                    foreach (var member in update.Message.NewChatMembers)
                    {
                        await Client.SendTextMessageAsync(member.Id,
                    $"Bienvenido {member.FirstName} {member.LastName} a Latino .NET Online!");
                    }
                }
            }


        }

        public override Task HandleFaultedUpdate(Update update, Exception e)
        {
            _logger.LogCritical("Exception thrown while handling an update");
            return Task.CompletedTask;
        }
    }
}
