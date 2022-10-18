using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using TgramMessage.send_any_group;

namespace TgramMessage.bot_with_communication
{
    public class CommunicationWithBot
    {
        public User _user;

        private readonly TelegramBotClient _telegramBotClient;
        private readonly ReceiverOptions _receiverOption;
        private readonly string _apiToken;
        public CommunicationWithBot(TelegramBotClient telegramBotClient, ReceiverOptions receiverOption, string apiToken)
        {
            _telegramBotClient = telegramBotClient;
            _receiverOption = receiverOption;
            _apiToken = apiToken;
        }

        public async Task Activated()
        {
            using var cts = new CancellationTokenSource();

            _telegramBotClient.StartReceiving(
                    updateHandler: HandleUpdateAsync,
                    pollingErrorHandler: HandlePollingErrorAsync,
                    receiverOptions: _receiverOption,
                    cancellationToken: cts.Token
                     );

            _user = await _telegramBotClient.GetMeAsync();

            Console.WriteLine($"Start listening for @{_user.Username}");
            Console.ReadLine();

            // Send cancellation request to stop bot
            cts.Cancel();
        }

        private async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Only process Message updates: https://core.telegram.org/bots/api#message
            if (update.Message is not { } message)
                return;
            // Only process text messages
            if (message.Text is not { } messageText)
                return;

            var chatId = message.Chat.Id;

            Console.WriteLine($"\n Received a '{messageText}' message in chat {chatId}.");


            #region checking the message
            string responseMessage = new CompileMessage().ResponseMessage(message,messageText);
            #endregion

            // Echo received message text
            Message sentMessage = await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "\n" + responseMessage, 
                cancellationToken: cancellationToken);
        }

        private Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }
    }
}
