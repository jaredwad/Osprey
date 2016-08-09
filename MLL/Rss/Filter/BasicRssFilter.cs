using System;
using System.Collections.Generic;

namespace com.virtus.JLib.Rss.Filter {
	public class BasicRssFilter : IRssFilter {
		public string filterChannelCategory   (string str) { return str; }
		public string filterChannelCopyright  (string str) { return str; }
		public string filterChannelDescription(string str) { return str; }
		public string filterChannelDocs       (string str) { return str; }
		public string filterChannelGenerator  (string str) { return str; }

		public RssReader.ChannelImage filterChannelImage(RssReader.ChannelImage str) { return str; }

		public string filterChannelLanguage      (string str) { return str; }
		public string filterChannelLastBuildDate (string str) { return str; }
		public string filterChannelLink			 (string str) { return str; }
		public string filterChannelManagingEditor(string str) { return str; }
		public string filterChannelPubDate		 (string str) { return str; }
		public string filterChannelSkipDays		 (string str) { return str; }
		public string filterChannelSkipHours	 (string str) { return str; }
		public string filterChannelTitle		 (string str) { return str; }
		public string filterChannelTtl			 (string str) { return str; }
		public string filterChannelWebMaster	 (string str) { return str; }

		public string filterItemAuthor(string str) { return str; }

		public List<string> filterItemCategories(List<string> list) { return list; }

		public string filterItemComments   (string str) { return str; }
		public string filterItemDescription(string str) { return str; }
		public string filterItemGuid	   (string str) { return str; }
		public string filterItemLink	   (string str) { return str; }

		public DateTime filterItemPubDate(DateTime date) { return date; }

		public RssItem.RssSource filterItemSource(RssItem.RssSource source) { return source; }

		public string filterItemTitle(string str) { return str; }
	}
}

