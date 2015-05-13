using System;
using Xamarin.Forms;
using Instagram.Models;
using System.Collections.Generic;
using Instagram.Models.Responses;
using System.Threading.Tasks;

namespace XamaGram
{
	public class ProfilePage : BaseContentPage
	{

		// Will be implemented in the future, 
		// for re-using this ProfilePage for IG
		// users other than the authenticated user.
		private string _InstagramUserId;

		StackLayout _Stack;
		double _bioFontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
		double _buttonLabelFontSize;

		public ProfilePage()
		{
			// Deal with diffences in font size rendering between platforms
			if (Device.OS == TargetPlatform.Android) {
				_buttonLabelFontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label));
			}
			else{
				_buttonLabelFontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
			}
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();

			// On iOS, OnAppearing() will call Build() and refresh
			// the content each time the page (iOS UIView) appears on screen.
			// On Android, OnAppearing() only gets called when
			// the page (Android Activiy) first appears on the screen, 
			// and does nothing on subsequent appearances, unless (the 
			// Android Activity) is destroyed and re-created.

			// As a consequence, some special logic exists in ProfilePages's
			// base class (BaseContentPage) in order to manually call OnAppearing()
			// when the Instagram login page is dismissed (Xamarin.Auth implementation
			// in XamaGram.Droid.LoginPageRenderer) only for Android. Otherwise, the
			// ProfilePage never gets rendered after a successful login on Android.

			await Build();
		}

		void PopulateProfileHeader(User user)
		{
			Title = "@" + user.Username;

			Grid mainGrid = new Grid {
				VerticalOptions = LayoutOptions.Start,
				RowDefinitions =  {
					new RowDefinition { Height = new GridLength(50, GridUnitType.Absolute) },
					new RowDefinition { Height = new GridLength(50, GridUnitType.Absolute) },
					new RowDefinition { Height = new GridLength(30, GridUnitType.Absolute) },
					new RowDefinition { Height = new GridLength(30, GridUnitType.Absolute) }
				},
				ColumnDefinitions =  {
					new ColumnDefinition { Width = new GridLength(100, GridUnitType.Absolute) },
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
				}
			};

			var profileImage = new Xamarin.Forms.Image(){ Aspect = Aspect.AspectFit };
			try {
				profileImage.Source = ImageSource.FromUri(new Uri(user.ProfilePicture.Replace("https://", "http://")));
			} catch (Exception ex) {
				System.Diagnostics.Debug.WriteLine(ex.Message);
			}
			mainGrid.Children.Add(profileImage, 0, 1, 0, 2);

			mainGrid.Children.Add(new Label {
				Text = user.Bio,
				XAlign = TextAlignment.Start,
				YAlign = TextAlignment.Center,
				FontSize = _bioFontSize
			}, 1, 3, 0, 2);

			var followButtonsGrid = new Grid() {
				VerticalOptions = LayoutOptions.FillAndExpand,
				RowDefinitions =  {
					new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
				},
				ColumnDefinitions =  {
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
				}
			};

			var mediaButtonsGrid = new Grid() {
				VerticalOptions = LayoutOptions.FillAndExpand,
				RowDefinitions =  {
					new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
				},
				ColumnDefinitions =  {
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
				}
			};

			mainGrid.Children.Add(followButtonsGrid, 0, 3, 2, 3);

			var followersBtn = new Button {
				Text = "Followers",
				TextColor = Color.Black,
				BackgroundColor = Color.FromHex("d2eefc"), 
				FontSize = _buttonLabelFontSize
			};
			followersBtn.Clicked += async delegate { await Navigation.PushAsync(new UsersPage("Followers", user.Id, FollowType.Followers)); };
			followButtonsGrid.Children.Add(followersBtn, 0, 1, 0, 1);

			var followingBtn = new Button {
				Text = "Following",
				TextColor = Color.Black,
				BackgroundColor = Color.FromHex("d2eefc"),
				FontSize = _buttonLabelFontSize
			};
			followingBtn.Clicked += async delegate { await Navigation.PushAsync(new UsersPage("Following", user.Id, FollowType.Following)); };
			followButtonsGrid.Children.Add(followingBtn, 1, 2, 0, 1);

			mainGrid.Children.Add(mediaButtonsGrid, 0, 3, 3, 4);

			var myFeedButton = new Button {
				Text = "My Feed",
				TextColor = Color.Black,
				BackgroundColor = Color.FromHex("d2eefc"),
				FontSize = _buttonLabelFontSize
			};
			myFeedButton.Clicked += async delegate { await Navigation.PushAsync(new ImageListPage("My Feed", ImageListType.MyFeed)); };
			mediaButtonsGrid.Children.Add(myFeedButton, 0, 1, 0, 1);

			var popularButton = new Button {
				Text = "Popular on IG",
				TextColor = Color.Black,
				BackgroundColor = Color.FromHex("d2eefc"),
				FontSize = _buttonLabelFontSize
			};
			popularButton.Clicked += async delegate { await Navigation.PushAsync(new ImageListPage("Popular", ImageListType.Popular)); };
			mediaButtonsGrid.Children.Add(popularButton, 1, 2, 0, 1);

			var likedButton = new Button {
				Text = "Liked by Me",
				TextColor = Color.Black,
				BackgroundColor = Color.FromHex("d2eefc"),
				FontSize = _buttonLabelFontSize
			};
			likedButton.Clicked += async delegate { await Navigation.PushAsync(new ImageListPage("Liked", ImageListType.Liked)); };
			mediaButtonsGrid.Children.Add(likedButton, 2, 3, 0, 1);

			mainGrid.RowSpacing = 5;
			mainGrid.ColumnSpacing = 5;

			_Stack.Children.Add(mainGrid);

			// set the content
			Content = _Stack;
		}

		void PopulateRecentMedia(IList<Media> medias)
		{
			ListView listView = new ListView(){
				RowHeight = 320,
				ItemsSource = medias,
				ItemTemplate = new DataTemplate(typeof(MyFeedImageCell))
			};

			_Stack.Children.Add(listView);
		}

		async Task Build()
		{
			if (IsAuthenticated) {
				Content = ActivityIndicator;
				try {
					// initialiize StackLayout
					_Stack = new StackLayout();

					UserResponse userResponse = new UserResponse();

					if (_InstagramUserId == null) {
						// fetch the authenticated user details from Instagram
						userResponse = await App.InstagramClient.GetMyUser();
					}
					else {
						// fetch the user details from Instagram for the given userId
						userResponse = await App.InstagramClient.GetUser(_InstagramUserId);
					}

					// build the user detail portion of the screen
					PopulateProfileHeader(userResponse.Data);

					// fetch the authenticated user's recent images from Instagram
					var mediaResponse = await App.InstagramClient.GetRecent(userResponse.Data.Id);
					PopulateRecentMedia(mediaResponse.Data);
				} catch (Exception) {
					Content = null;	
				}
			} else {
				Content = null;
			}
		}
	}
}