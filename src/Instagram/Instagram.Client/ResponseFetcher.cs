using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Instagram.Models.Responses;

namespace Instagram.Client
{
	internal class ResponseFetcher<T> where T : IInstagramResponse
	{
		string _BaseUri;

		public ResponseFetcher(string baseUri)
		{
			_BaseUri = baseUri;
		}

		internal async Task<T> GetResponseAsync(string requestUri)
		{
			using (var client = new HttpClient ()) {
				client.BaseAddress = new Uri (_BaseUri);
				var response = await client.GetAsync(requestUri).ConfigureAwait(false);
				response.EnsureSuccessStatusCode();
				var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
				return JsonConvert.DeserializeObject<T>(content);
			}
		}
	}
}

