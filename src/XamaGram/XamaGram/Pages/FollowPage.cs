using System;
using System.Linq;
using Xamarin.Forms;
using Instagram.Models.Responses;
using System.Collections.Generic;
using Instagram.Models;

namespace XamaGram
{
	public class UsersPage : BaseContentPage
	{
		FollowType _FollowType;
		string _UserId;

		public UsersPage(string title, string userId, FollowType followType)
		{
			Title = title;

			_FollowType = followType;

			_UserId = userId;
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			if (IsAuthenticated) {
				Content = ActivityIndicator;
				try {
					UsersResponse usersResponse;
					switch (_FollowType)
					{
					case FollowType.Followers:
						// fetch my followers
						usersResponse = await App.InstagramClient.GetFollowers(_UserId);

						// build the listview for my followers
//						PopulateFollowItems(usersResponse.Data);
						PopulateFollowItems(usersResponse.Data.Where(x => !x.ProfilePicture.Contains("anonymousUser")));
						break;
					case FollowType.Following:
						// fetch who I'm following
						usersResponse = await App.InstagramClient.GetFollowing(_UserId);

						// build the listview for who I'm following
//						PopulateFollowItems(usersResponse.Data);
						PopulateFollowItems(usersResponse.Data.Where(x => !x.ProfilePicture.Contains("anonymousUser")));
						break;
					}
				} catch (Exception) {
					Content = null;	
				}
			} else {
				Content = null;
			}
		}

		void PopulateFollowItems(IEnumerable<User> users)
		{
			ListView listView = new ListView(){
				RowHeight = 320,
				ItemsSource = users,
				ItemTemplate = new DataTemplate(typeof(ProfilePicImageCell)) {
				}
			};

			Content = listView;
		}
	}
}


