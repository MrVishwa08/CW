using CW.Services;
using CW.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CW
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
         [STAThread]
        static void Main()
        {
         Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);
          Application.Run(new Form1());
         } 

        /* static async Task Main()
            {
                var httpService = new HttpService();

                // 🔹 Test Case 1: Valid URL
                Console.WriteLine("Testing valid URL...");
                var result1 = await httpService.SendGetRequestAsync("https://gog.com");
                PrintResult(result1);

                // 🔹 Test Case 2: Invalid URL (400)
                Console.WriteLine("\nTesting invalid URL...");
                var result2 = await httpService.SendGetRequestAsync("htp://invalid-url");
                PrintResult(result2);

                // 🔹 Test Case 3: Forbidden URL (403)
                Console.WriteLine("\nTesting forbidden URL...");
                var result3 = await httpService.SendGetRequestAsync("https://httpstat.us/403");
                PrintResult(result3);

                // 🔹 Test Case 4: Not Found URL (404)
                Console.WriteLine("\nTesting not found URL...");
                var result4 = await httpService.SendGetRequestAsync("https://httpstat.us/404");
                PrintResult(result4);
            }

            static void PrintResult(HttpResponseData result)
            {
                Console.WriteLine($"Status Code: {result.StatusCode}");
                Console.WriteLine($"Description: {result.StatusDescription}");
                Console.WriteLine($"Success: {result.IsSuccess}");
                Console.WriteLine();
            } 
        static async Task Main()
        {
            var httpService = new HttpService();
            var htmlParser = new HtmlParser();

            // Fetch HTML
            var response = await httpService.SendGetRequestAsync("https://example.com");

            if (response.IsSuccess)
            {
                string title = htmlParser.ExtractTitle(response.HtmlContent);
                var urls = htmlParser.ExtractFirstFiveUrls(response.HtmlContent);

                Console.WriteLine($"Title: {title}");
                Console.WriteLine("First 5 URLs:");
                foreach (var url in urls)
                    Console.WriteLine($"- {url}");
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusDescription}");
            }
        } */
    }
}

