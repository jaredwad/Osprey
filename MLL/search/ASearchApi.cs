using System;
using System.Collections.Generic;

namespace com.virtus.MLL.search {
	public abstract class ASearchApi {
		public string BaseUrl { get; set; }
		public string License { get; set; }
		public string Language { get; set; }

		public double Throttle { get; set; }

		/// <summary>
		///   <param name="license" ></param>
		///   <param name="throttle"></param>
		///   <param name="language"></param>
		/// </summary>
		public ASearchApi(string baseUrl, string license = "", double throttle = 1.0, string language = "en") {
			BaseUrl = baseUrl;
			License = license;
			Throttle = throttle;
			Language = language;
		}

		public abstract ISearchResult Search(string query);
	}

	public interface ISearchResult {
		Dictionary<Object, Object> Results { get; }
	}
}

