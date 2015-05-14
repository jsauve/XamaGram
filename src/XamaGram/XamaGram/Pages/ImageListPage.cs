using System;

using Xamarin.Forms;
using Instagram.Models.Responses;
using System.Linq;
using Instagram.Models;
using System.Collections.Generic;

namespace XamaGram
{
	public class ImageListPage : BaseContentPage
	{
		ImageListType _FollowType;

		public ImageListPage(string title, ImageListType imageListType)
		{
			Title = title;

			_FollowType = imageListType;
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			if (IsAuthenticated) {
				Content = ActivityIndicator;
				try {
					MediasResponse imageResponse = new MediasResponse();
					switch (_FollowType)
					{
					case ImageListType.MyFeed:
						imageResponse = await App.InstagramClient.GetMyFeedAsync();
						break;
					case ImageListType.Popular:
						// fetch my followers
						imageResponse = await App.InstagramClient.GetPopularAsync();
						break;
					case ImageListType.Liked:
						// fetch who I'm following
						imageResponse = await App.InstagramClient.GetMyLikedAsync();
						break;
					}
					PopulateImageItems(imageResponse.Data);
				} catch (Exception) {
					Content = null;	
				}
			} else {
				Content = null;
			}
		}

		void PopulateImageItems(IEnumerable<Media> users)
		{
			ListView listView = new ListView(){
				RowHeight = 320,
				ItemsSource = users,
				ItemTemplate = new DataTemplate(typeof(InstagramImageCell)) {
				}
			};

			Content = listView;
		}
	}
}


