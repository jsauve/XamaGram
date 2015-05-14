using Instagram.Models.Responses;
using System.Threading.Tasks;

namespace Instagram.Client
{
	public interface IInstagramClient
	{
		Task<UserResponse> GetUserAsync(string userId);
		Task<UserResponse> GetMyUserAsync();
		Task<MediasResponse> GetMyFeedAsync(int count = 30);
		Task<MediasResponse> GetRecentAsync(string userId, int count = 30);
		Task<MediasResponse> GetMyLikedAsync(int count = 30);

		Task<UsersResponse> GetFollowersAsync(string userId);
		Task<UsersResponse> GetFollowingAsync(string userId);

		Task<MediaResponse> GetMediaByIdAsync(string mediaId);
		Task<MediaResponse> GetMediaByShortCodeAsync(string shortCode);
		Task<MediasResponse> GetPopularAsync();
	}
}

