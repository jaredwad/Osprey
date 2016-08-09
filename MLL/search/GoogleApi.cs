using System;
using System.Net;

namespace com.virtus.MLL.search {
	public class GoogleApi : ASearchApi {

		public GoogleApi(string baseUrl = null, string license = null, double throttle = 1, string language = "en")
		  : base(baseUrl, license, throttle, language) {
			if (string.IsNullOrWhiteSpace(BaseUrl))
				BaseUrl = "https://www.googleapis.com/customsearch/v1?key=INSERT_YOUR_API_KEY&cx=017576662512468239146:omuauf_lfve&q=lectures";

		}

		public override ISearchResult Search(string query) {
			string queryString = BaseUrl + query;

			Console.Out.WriteLine("http://www.google.com");

			var result = WebRequest.Create(queryString).GetResponse();

			var stream = result.GetResponseStream();

			System.IO.StreamReader sr = new System.IO.StreamReader(stream);


			while(!sr.EndOfStream)
				Console.Out.WriteLine(sr.ReadLine());

			return null;
		}
	}
}

