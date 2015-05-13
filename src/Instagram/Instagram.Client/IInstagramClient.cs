using System;
using Instagram.Models;
using Instagram.Models.Responses;
using System.Threading.Tasks;

namespace Instagram.Client
{
	public interface IInstagramClient
	{
		Task<UserResponse> GetUser(string userId);
		Task<UserResponse> GetMyUser();
		Task<MediasResponse> GetMyFeed(int count = 30);
		Task<MediasResponse> GetRecent(string userId, int count = 30);
		Task<MediasResponse> GetMyLiked(int count = 30);

		Task<UsersResponse> GetFollowers(string userId);
		Task<UsersResponse> GetFollowing(string userId);

		Task<MediaResponse> GetMediaById(string mediaId);
		Task<MediaResponse> GetMediaByShortCode(string shortCode);
		Task<MediasResponse> GetPopular();
	}
}

