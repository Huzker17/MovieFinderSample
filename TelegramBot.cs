using ConsoleApp1.Interfaces;
using System.Drawing;
using System.Net;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ConsoleApp1
{
    public class TelegramBot
    {
        private static string token = "5671941125:AAFclwvke3W5kAD6XrBX4RLYO4WAc1wZheU";
        private static ITelegramBotClient bot;
        private static CancellationTokenSource cts;
        private IScreenShoter _screenShoter;
        public TelegramBot(IScreenShoter screenShoter)
        {
            _screenShoter = screenShoter;
            bot = new TelegramBotClient(token);
            cts = new CancellationTokenSource();
        }
        public void Start()
        {
            bot.StartReceiving(updateHandler: Update, errorHandler: Error);
        }


        public async Task Update(ITelegramBotClient bot, Update update, CancellationToken token)
        {
            var message = update.Message;
            if(message.Text != null)
            {
                if (Uri.IsWellFormedUriString(message.Text, UriKind.Absolute))
                {
                    Uri uri = new Uri(message.Text);
                    _screenShoter.TakeScreenShot(uri);
                    //SeleniumService service = new SeleniumService();
                    //service.seleniumScreenShot(uri);
                    await bot.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: "I did a screenshot");
                }
            }

        }
        public static async Task Error(ITelegramBotClient bot, Exception exception, CancellationToken token)
        {
            Console.WriteLine(exception);
            throw new NotImplementedException();
        }
    }
}
