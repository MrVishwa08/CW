using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CW.Utilities
{
   public class HtmlParser
    {
        public string ExtractTitle(string html)
        {
            if (string.IsNullOrWhiteSpace(html))
                return "No HTML content";

            // Use Regex to find <title>...</title>
            Match match = Regex.Match(html, @"<title>(.*?)</title>", RegexOptions.IgnoreCase | RegexOptions.Singleline);

            if (match.Success)
            {
                // Trim to remove unwanted spaces or newlines
                return match.Groups[1].Value.Trim();
            }

            return "No Title Found";
        }

        public List<string> ExtractFirstFiveUrls(string html)
        {
            var urls = new List<string>();

            if (string.IsNullOrWhiteSpace(html))
                return urls;

            // Regex to match href="URL"
            MatchCollection matches = Regex.Matches(html, @"href\s*=\s*[""'](.*?)[""']", RegexOptions.IgnoreCase);

            int count = 0;
            foreach (Match match in matches)
            {
                if (match.Success)
                {
                    string url = match.Groups[1].Value;

                    // Optional: ignore mailto: or javascript: links
                    if (!url.StartsWith("mailto:", StringComparison.OrdinalIgnoreCase) &&
                        !url.StartsWith("javascript:", StringComparison.OrdinalIgnoreCase))
                    {
                        urls.Add(url);
                        count++;
                    }
                }

                if (count >= 5) break;
            }

            return urls;
        }
    }
}
