using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using com.virtus.JLib.Rss.Filter;

namespace com.virtus.JLib.Rss {
	public class RssReader {
		//Required channel elements
		public string Title;
		public string Link;
		public string Description;

		//Optional channel elements
		public string Language; //The language the channel is written in
		public string Copyright; //Copyright notice for content in the channel. 
		public string ManagingEditor; //Email address for person responsible for editorial content.
		public string webMaster; //Email address for person responsible for technical issues relating to channel.
		public string pubDate; //The publication date for the content in the channel.
		public string lastBuildDate; //The last time the content of the channel changed.
		public string category; //Specify one or more categories that the channel belongs to.
		public string generator; //A string indicating the program used to generate the channel.
		public string docs; //A URL that points to the documentation for the format used in the RSS file.
		//public string cloud; //Allows processes to register with a cloud to be notified of updates to the channel
		public string ttl; //number of minutes that indicates how long a channel can be cached before refreshing from the source
		public ChannelImage image; //Specifies a GIF, JPEG or PNG image that can be displayed with the channel.
		//public string textInput; //Specifies a text input box that can be displayed with the channel.
		public string skipHours; //A hint for aggregators telling them which hours they can skip.
		public string skipDays; //A hint for aggregators telling them which days they can skip.

		public List<RssItem> items;

		public RssReader(string Url){
			read(Url);
		}

		private void read(string Url, IRssFilter filter = null) {
			if (filter == null)
				filter = new BasicRssFilter();

			XDocument doc = XDocument.Load(Url);

			XElement channel = doc.Descendants("channel").First();

			Title = filter.filterChannelTitle(channel.Element("title").Value);
			Link = filter.filterChannelLink(channel.Element("link").Value);
			Description = filter.filterChannelDescription(channel.Element("description").Value);

			Language 		= filter.filterChannelLanguage(channel.Element("language").Value);
			Copyright 		= filter.filterChannelCopyright(channel.Element("Copyright").Value);
			ManagingEditor 	= filter.filterChannelManagingEditor(channel.Element("ManagingEditor").Value);
			webMaster      	= filter.filterChannelWebMaster(channel.Element("webMaster").Value);
			pubDate 		= filter.filterChannelPubDate(channel.Element("pubDate").Value);
			lastBuildDate 	= filter.filterChannelLastBuildDate(channel.Element("lastBuildDate").Value);
			category 		= filter.filterChannelCategory(channel.Element("category").Value);
			generator 		= filter.filterChannelGenerator(channel.Element("generator").Value);
			docs 			= filter.filterChannelDocs(channel.Element("docs").Value);
			ttl 			= filter.filterChannelTtl(channel.Element("ttl").Value);
			skipHours 		= filter.filterChannelSkipHours(channel.Element("skipHours").Value);
			skipDays 		= filter.filterChannelSkipDays(channel.Element("skipDays").Value);

			image = filter.filterChannelImage(new ChannelImage(channel.Element("skipDays")));

			items = new List<RssItem>();

			foreach(var item in channel.Elements("item")){
				items.Add(new RssItem(item, filter));
			}
		}

		public string getInfo(){
			return string.Format("Title:{0}\nLink:{1}\nDescription:{2}\n", Title, Link, Description);
		}

		public override string ToString(){
			return getInfo();
		}

		public class ChannelImage {
			public ChannelImage(XElement el){
				URL = el.Element("url").Value;
				title = el.Element("title").Value;
				link = el.Element("link").Value;

				try {
					width = int.Parse(el.Element("url").Value);
					height = int.Parse(el.Element("url").Value);
				} catch(Exception){
					width  = -1;
					height = -1;
				}
			}

			//Required
			public string URL; //URL of a GIF, JPEG or PNG image that represents the channel
			public string title; //describes the image
			public string link; //URL of the site

			//Optional
			public int width; //Width of the image
			public int height; //Height of the image
		}
	}
}

