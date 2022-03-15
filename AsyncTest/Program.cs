using System;
using System.Net;
using System.Threading;

namespace AsyncTest
{
    internal class Program
    {
        static bool downloading = false;
        static void Main(string[] args)
        {
            var webClient = new WebClient();
            Console.Write("Download in progress .");
            string url = "https://codeavecjonathan.com/res/bateau.jpg";

            //Sync Version
            webClient.DownloadFile(url, "bateau.jpg");

            downloading = true;
            webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
            webClient.DownloadFileAsync(new Uri(url), "bateau.jpg");

            while (downloading)
            {
                Thread.Sleep(1);
                if (downloading)
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine("End of program");
        }

        private static void WebClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Console.WriteLine(" Download Complete");
            downloading = false;
        }
    }
}
