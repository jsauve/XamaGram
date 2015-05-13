using Xamarin.Forms;
using Instagram.Client;
using System;
using System.Threading.Tasks;
using XamaGram.Models;

namespace XamaGram
{
	public class App : Application
	{
		static NavigationPage _NavPage;

		public static INavigation Navigation { get; private set; }

		public static OAuthSettings XamarinAuthSettings { get; private set; }

		/// <summary>
		/// A static intance of IInstagramClient.
		/// </summary>
		/// <value>The Instagram client.</value>
		/// <remarks>Not the cleanest way to use the Instagram, but it works. IoC/DI would be better (and recommended), but this app is meant to be simple.</remarks>
		public static IInstagramClient InstagramClient { get; private set; }

		public static bool IsAuthenticated {
			get { return (!String.IsNullOrWhiteSpace(Token)); }
		}

		/// <summary>
		/// The Instagram API token returned from a successful login. This token is unique to each Instagram user.
		/// </summary>
		/// <value>The Instagram API token.</value>
		public static string Token { get; private set;}

		public App()
		{
			// clientId: Your OAuth2 client id (get from Instagram API management portal)
			// scope: The scopes for the particular API you're accessing. The format for this will vary by API. ("basic" is all you need for this spp)
			// authorizeUrl: The auth URL for the service (at the time of this writing, it's "https://api.instagram.com/oauth/authorize/")
			// redirectUrl: The redirect URL for the service (as you've specified in the Instagram API management portal)

			// If you'd like to know more about how to integrate with an OAuth provider, 
			// I personally like the Instagram API docs: http://instagram.com/developer/authentication/

			XamarinAuthSettings = 
				new OAuthSettings(
					clientId: "",													
					scope: "basic",  												
					authorizeUrl: "https://api.instagram.com/oauth/authorize/",  	
					redirectUrl: "");   											

			// Hold on to the NavigationPage as a static, so that we can easily access it via App later.
			_NavPage = new NavigationPage(new ProfilePage());
			Navigation = _NavPage.Navigation;

			// set the app's main page, which in this case is a NAvigationPage.
			MainPage = _NavPage;
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}

		public static void CompleteLogin(string token)
		{
			Token = token;

			InstagramClient = new InstagramClient(token);
		}

		// Not currently being used anywhere in the app, but hopefully soon.
		public static void Logout()
		{
			Token = null;

			MessagingCenter.Send<App> ((App)App.Current, "LoggedOut");
		}

		// Allows the LoginPageRenderers to signal the app to pop off the login modal.
		public async static Task PerformSuccessfulLoginAction()
		{
			await _NavPage.Navigation.PopModalAsync();
		}
	}
}

