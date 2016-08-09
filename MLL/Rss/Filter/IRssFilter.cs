using System;
using System.Collections.Generic;

namespace com.virtus.JLib.Rss.Filter {
	public interface IRssFilter {
		//Channel
		string filterChannelTitle			(string str);
		string filterChannelLink			(string str);
		string filterChannelDescription		(string str);
		string filterChannelLanguage		(string str);
		string filterChannelCopyright		(string str);
		string filterChannelManagingEditor	(string str);
		string filterChannelWebMaster		(string str);
		string filterChannelPubDate			(string str);
		string filterChannelLastBuildDate	(string str);
		string filterChannelCategory		(string str);
		string filterChannelGenerator		(string str);
		string filterChannelDocs			(string str);
		//string cloud;
		string filterChannelTtl(string str);
		RssReader.ChannelImage filterChannelImage(RssReader.ChannelImage str);
		//string textInput;
		string filterChannelSkipHours(string str);
		string filterChannelSkipDays (string str);


		//Item
		string filterItemTitle			(string str);
		string filterItemLink			(string str);
		string filterItemDescription	(string str);
		string filterItemAuthor			(string str);

		List<string> filterItemCategories(List<string> list);

		string filterItemComments(string str);
		//public string enclosure;
		string filterItemGuid(string str);
		DateTime filterItemPubDate(DateTime date);
		RssItem.RssSource filterItemSource(RssItem.RssSource source);
	}
}

