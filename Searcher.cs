using System.Net;
using ConsoleApp1.Interfaces;
using System;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Security.Policy;
using System.Drawing;

namespace ConsoleApp1
{
    public class Searcher : ISearcher
    {
        public async void Search(byte[] bytes)
        {
            HttpClient client = new HttpClient();
            ByteArrayContent baContent = new ByteArrayContent(bytes);
            MultipartFormDataContent content2 = new MultipartFormDataContent();
            content2.Add(baContent, "File", "filename.png");
            using (HttpResponseMessage response = await client.PostAsync("https://www.google.com/search?tbs=",content2))
            {
                using (HttpContent content = response.Content)
                {
                    string result = await content.ReadAsStringAsync();

                    Console.WriteLine(result);
                }
            }
        }
    }
}
