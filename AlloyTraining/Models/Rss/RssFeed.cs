using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace AlloyTraining.Models.Rss
{
    public class RssFeed
    {
        public string Time { get; private set; }
        public string RssUrl { get; set; }
        public int MaxCount { get; set; }
        public List<RssItem> RssItems { get; set; }

        public RssFeed(string rssUrl, int maxCount = 5)
        {
            this.RssUrl = rssUrl;
            this.MaxCount = maxCount;
            this.Time = DateTime.Now.ToString("hh:mm:ss");
            this.RssItems = FetchRssItems();
        }

        public List<RssItem> FetchRssItems()
        {
            try
            {
                var rssDocument = XDocument.Load(RssUrl);

                var posts = from item in rssDocument.Descendants("item").Take(this.MaxCount)
                            select new RssItem()
                            {
                                Title = item.Element("title").Value,
                                Url = item.Element("link").Value,
                                Description = item.Element("description").Value,
                            };
                return posts.ToList();
            }
            catch (System.Net.WebException)
            {

            }
            catch (System.IO.FileNotFoundException)
            {

            }
            return null;
        }
    }
}