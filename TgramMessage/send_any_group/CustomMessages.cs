using System.Text;

namespace TgramMessage.send_any_group
{
    public class CustomMessages
    {
        private readonly string _apiUrlString;
        private readonly string _apiToken;
        private readonly string _chatID;

        public CustomMessages(string apiUrlString, string apiToken,  string chatID)
        {
            _apiUrlString = apiUrlString;
            _apiToken = apiToken;
            _chatID = chatID;
        }

        public async void SendAsync(string textMessage)
        {
           string url = String.Format(_apiUrlString
                                                    , _apiToken, _chatID, textMessage
                                           );

            //WebRequest request = WebRequest.Create(urlString);
            HttpClient client = new HttpClient();
            Stream rs = await client.GetStreamAsync(url);
            //Stream rs = request.GetResponse().GetResponseStream();

            StreamReader reader = new StreamReader(rs);
            string? line = "";
            StringBuilder sb = new StringBuilder();

            while (line != null)
            {
                line = reader.ReadLine();
                if (line != null)
                    sb.Append(line);
            }
            string response = sb.ToString();

            Console.WriteLine("\n\n\n res => {0}",response);
            Console.WriteLine("\n \n -: {0}", textMessage);

        }

    }
}
