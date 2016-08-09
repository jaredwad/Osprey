using System;
using System.Collections.Generic;
using System.Xml.Linq;
using com.virtus.JLib.Rss.Filter;

namespace com.virtus.JLib.Rss {
	public class RssItem {
		//Optional
		public string Title; //The title of the item.
		public string Link; //The URL of the item.
		public string Description; //The item synopsis.
		public string author; //Email address of the author of the item.
		public List<string> categories; //Includes the item in one or more categories.
		public string comments; //URL of a page for comments relating to the item.
		//public string enclosure; //Describes a media object that is attached to the item.
		public string guid; //A string that uniquely identifies the item.
		public DateTime pubDate; //Indicates when the item was published.
		public RssSource source; //The RSS channel that the item came from

		public RssItem(XElement item, IRssFilter filter = null) {
			if (filter == null)
				filter = new BasicRssFilter();

			Title = filter.filterItemTitle(item.Element("title").Value);
			Link = filter.filterItemLink(item.Element("link").Value);
			Description = filter.filterItemDescription(item.Element("description").Value);
			author = filter.filterItemAuthor(item.Element("author").Value);
			comments = filter.filterItemComments(item.Element("comments").Value);
			guid = filter.filterItemGuid(item.Element("guid").Value);

			categories = new List<string>();
			foreach(var el in item.Elements("category")){
				categories.Add(el.Value);
			}
			categories = filter.filterItemCategories(categories);

		}

		public class RssSource{
			public string Title;
			public string URL;
		}
	}
}

