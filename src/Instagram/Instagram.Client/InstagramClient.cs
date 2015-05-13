using System;
using Instagram.Models.Responses;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Instagram.Client
{
	public class InstagramClient : IInstagramClient
	{
		const string API_SERVICE_URL = "https://api.instagram.com/v1/";

		readonly string _AccessToken;

		public InstagramClient (string accessToken)
		{
			_AccessToken = accessToken;
		}

		#region IIGClient implementation

		public async Task<UserResponse> GetUser(string userId)
		{
			string requestUri = String.Format ("users/{0}/?access_token={1}", userId, _AccessToken);

			using (var client = new HttpClient ()) {
				client.BaseAddress = new Uri (API_SERVICE_URL);
				var response = await client.GetAsync(requestUri);
				response.EnsureSuccessStatusCode();
				var content = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<UserResponse>(content);
			}
		}

		public async Task<UserResponse> GetMyUser()
		{
			return await GetUser("self");
		}

		public async Task<MediasResponse> GetMyFeed(int count = 30)
		{
			string requestUri = String.Format ("users/self/feed?access_token={0}&count={1}", _AccessToken, count);

			using (var client = new HttpClient ()) {
				client.BaseAddress = new Uri (API_SERVICE_URL);
				var response = await client.GetAsync(requestUri);
				response.EnsureSuccessStatusCode();
				var content = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<MediasResponse>(content);
			}
		}

		public async Task<MediasResponse> GetRecent(string userId, int count = 30)
		{
			string requestUri = String.Format ("users/{0}/media/recent/?access_token={1}&count={2}", userId, _AccessToken, count);

			using (var client = new HttpClient ()) {
				client.BaseAddress = new Uri (API_SERVICE_URL);
				var response = await client.GetAsync(requestUri);
				response.EnsureSuccessStatusCode();
				var content = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<MediasResponse>(content);
			}
		}

		public async Task<MediasResponse> GetMyLiked(int count = 30)
		{
			string requestUri = String.Format ("users/self/media/liked?access_token={0}&count={1}", _AccessToken, count);

			using (var client = new HttpClient ()) {
				client.BaseAddress = new Uri (API_SERVICE_URL);
				var response = await client.GetAsync(requestUri);
				response.EnsureSuccessStatusCode();
				var content = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<MediasResponse>(content);
			}
		}

		public async Task<UsersResponse> GetFollowers(string userId)
		{
			string requestUri = String.Format ("users/{0}/followed-by?access_token={1}", userId, _AccessToken);

			using (var client = new HttpClient ()) {
				client.BaseAddress = new Uri (API_SERVICE_URL);
				var response = await client.GetAsync(requestUri);
				response.EnsureSuccessStatusCode();
				var content = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<UsersResponse>(content);
			}
		}

		public async Task<UsersResponse> GetFollowing(string userId)
		{
			string requestUri = String.Format ("users/{0}/follows?access_token={1}", userId, _AccessToken);

			using (var client = new HttpClient ()) {
				client.BaseAddress = new Uri (API_SERVICE_URL);
				var response = await client.GetAsync(requestUri);
				response.EnsureSuccessStatusCode();
				var content = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<UsersResponse>(content);
			}
		}

		public async Task<MediaResponse> GetMediaById(string mediaId)
		{
			string requestUri = String.Format ("media/{0}?access_token={1}", mediaId, _AccessToken);

			using (var client = new HttpClient ()) {
				client.BaseAddress = new Uri (API_SERVICE_URL);
				var response = await client.GetAsync(requestUri);
				response.EnsureSuccessStatusCode();
				var content = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<MediaResponse>(content);
			}
		}

		public async Task<MediaResponse> GetMediaByShortCode(string shortCode)
		{
			string requestUri = String.Format ("media/shortcode/{0}?access_token={1}", shortCode, _AccessToken);

			using (var client = new HttpClient ()) {
				client.BaseAddress = new Uri (API_SERVICE_URL);
				var response = await client.GetAsync(requestUri);
				response.EnsureSuccessStatusCode();
				var content = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<MediaResponse>(content);
			}
		}

		public async Task<MediasResponse> GetPopular()
		{
			string requestUri = String.Format ("media/popular?access_token={0}", _AccessToken);

			using (var client = new HttpClient ()) {
				client.BaseAddress = new Uri (API_SERVICE_URL);
				var response = await client.GetAsync(requestUri);
				response.EnsureSuccessStatusCode();
				var content = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<MediasResponse>(content);
			}
		}
		#endregion
	}
}

