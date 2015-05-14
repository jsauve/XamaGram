using System;
using Instagram.Models.Responses;
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

		public async Task<UserResponse> GetUserAsync(string userId)
		{
			string requestUri = String.Format ("users/{0}/?access_token={1}", userId, _AccessToken);

			var responseFetcher = new ResponseFetcher<UserResponse>(API_SERVICE_URL);
			return await responseFetcher.GetResponseAsync(requestUri).ConfigureAwait(false);
		}

		public async Task<UserResponse> GetMyUserAsync()
		{
			return await GetUserAsync("self").ConfigureAwait(false);
		}

		public async Task<MediasResponse> GetMyFeedAsync(int count = 30)
		{
			string requestUri = String.Format ("users/self/feed?access_token={0}&count={1}", _AccessToken, count);

			var responseFetcher = new ResponseFetcher<MediasResponse>(API_SERVICE_URL);
			return await responseFetcher.GetResponseAsync(requestUri).ConfigureAwait(false);
		}

		public async Task<MediasResponse> GetRecentAsync(string userId, int count = 30)
		{
			string requestUri = String.Format ("users/{0}/media/recent/?access_token={1}&count={2}", userId, _AccessToken, count);

			var responseFetcher = new ResponseFetcher<MediasResponse>(API_SERVICE_URL);
			return await responseFetcher.GetResponseAsync(requestUri).ConfigureAwait(false);
		}

		public async Task<MediasResponse> GetMyLikedAsync(int count = 30)
		{
			string requestUri = String.Format ("users/self/media/liked?access_token={0}&count={1}", _AccessToken, count);

			var responseFetcher = new ResponseFetcher<MediasResponse>(API_SERVICE_URL);
			return await responseFetcher.GetResponseAsync(requestUri).ConfigureAwait(false);
		}

		public async Task<UsersResponse> GetFollowersAsync(string userId)
		{
			string requestUri = String.Format ("users/{0}/followed-by?access_token={1}", userId, _AccessToken);

			var responseFetcher = new ResponseFetcher<UsersResponse>(API_SERVICE_URL);
			return await responseFetcher.GetResponseAsync(requestUri).ConfigureAwait(false);
		}

		public async Task<UsersResponse> GetFollowingAsync(string userId)
		{
			string requestUri = String.Format ("users/{0}/follows?access_token={1}", userId, _AccessToken);

			var responseFetcher = new ResponseFetcher<UsersResponse>(API_SERVICE_URL);
			return await responseFetcher.GetResponseAsync(requestUri).ConfigureAwait(false);
		}

		public async Task<MediaResponse> GetMediaByIdAsync(string mediaId)
		{
			string requestUri = String.Format ("media/{0}?access_token={1}", mediaId, _AccessToken);

			var responseFetcher = new ResponseFetcher<MediaResponse>(API_SERVICE_URL);
			return await responseFetcher.GetResponseAsync(requestUri).ConfigureAwait(false);
		}

		public async Task<MediaResponse> GetMediaByShortCodeAsync(string shortCode)
		{
			string requestUri = String.Format ("media/shortcode/{0}?access_token={1}", shortCode, _AccessToken);

			var responseFetcher = new ResponseFetcher<MediaResponse>(API_SERVICE_URL);
			return await responseFetcher.GetResponseAsync(requestUri).ConfigureAwait(false);
		}

		public async Task<MediasResponse> GetPopularAsync()
		{
			string requestUri = String.Format ("media/popular?access_token={0}", _AccessToken);

			var responseFetcher = new ResponseFetcher<MediasResponse>(API_SERVICE_URL);
			return await responseFetcher.GetResponseAsync(requestUri).ConfigureAwait(false);
		}
		#endregion
	}
}

