using System;
using System.ServiceModel.Syndication;
using System.Xml;

namespace com.virtus.JLib.Rss {
	public class ARss {
		string url = "http://rss.nytimes.com/services/xml/rss/nyt/Business.xml";

		public ARss() {
		}

		public void getFeed() {
			using (XmlReader reader = XmlReader.Create(url)) {
				SyndicationFeed feed = SyndicationFeed.Load(reader);
				Console.WriteLine(feed.Title.Text);
				Console.WriteLine(feed.Links[0].Uri);
				foreach (SyndicationItem item in feed.Items) {
					Console.WriteLine(item.Title.Text);
				}
			}
		}
	}
}

