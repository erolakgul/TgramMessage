using Telegram.Bot.Types;

namespace TgramMessage.bot_with_communication
{
    public class CompileMessage
    {

        public CompileMessage()
        {

        }

        public string ResponseMessage(Message message, string text)
        {
            string response = String.Empty;


            if (text.StartsWith("/cities"))
            {
                response = "Which countries' cities do you want to list?";
            }
            else if (text.StartsWith("/turkey"))
            {
                response = "\n  Istanbul \n Izmır \n Aydın";
            }
            else if (text.StartsWith("/time"))
            {
                response = DateTime.Now.ToString();
            }
            else
            {
                response = "undefined message, would you like to report ?";
            }


            return response;
        }

    }
}
