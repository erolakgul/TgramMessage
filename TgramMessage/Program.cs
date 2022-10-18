//https://telegrambots.github.io/book/1/example-bot.html

// ilk olarak botfather da /newbot ile bot oluşturulur
// bot gruba eklenir
//https://www.youtube.com/watch?v=zOFNWyFsxf0 admin to bot
//https://stackoverflow.com/questions/38565952/how-to-receive-messages-in-group-chats-using-telegram-bot-api
// bot un her mesajı alması handle etmesi için botfather da /setprivacy yazıp,@botname i girdikten sonra disable yazıp
// bot un tüm mesajları alması sağlanır.

using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using TgramMessage.bot_with_communication;

#region tg token
string apiToken = "5617450772:AAEb5b9HnAnRg8PNO69I35KTrXlFz8kBh8w"; 
#endregion

#region define tg token
TelegramBotClient botClient = new(apiToken);
#endregion

#region define attr coming from data
ReceiverOptions receiverOption = new ReceiverOptions
{
    AllowedUpdates = Array.Empty<UpdateType>() // receive all update types
};
#endregion

#region communicate with bot each other
CommunicationWithBot communicationWithBot = new(botClient, receiverOption, apiToken);
await Task.Run(() => communicationWithBot.Activated());
#endregion


#region sending any tg group
//string apiUrlString = "https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}";
//string chatId = "@test_group_ea";

//CustomMessages customMessages = new(apiUrlString, apiToken, chatId);
//var user = await botClient.GetMeAsync();
//customMessages.SendAsync(String.Format("{0} :: {1}", Guid.NewGuid(), user.Username));
#endregion

Console.ReadKey();