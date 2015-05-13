using System;
using Xamarin.Forms;
using XamaGram.Droid;
using Xamarin.Forms.Platform.Android;
using Xamarin.Auth;
using Android.App;
using XamaGram;

[assembly: ExportRenderer (typeof (LoginPage), typeof (LoginPageRenderer))]

namespace XamaGram.Droid
{
	public class LoginPageRenderer : PageRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
		{
			base.OnElementChanged(e);

			// this is a ViewGroup - so should be able to load an AXML file and FindView<>
			var activity = this.Context as Activity;

			var auth = new OAuth2Authenticator (
				clientId: App.XamarinAuthSettings.ClientId, // your OAuth2 client id
				scope: App.XamarinAuthSettings.Scope, // The scopes for the particular API you're accessing. The format for this will vary by API.
				authorizeUrl: new Uri (App.XamarinAuthSettings.AuthorizeUrl), // the auth URL for the service
				redirectUrl: new Uri (App.XamarinAuthSettings.RedirectUrl)); // the redirect URL for the service

			auth.Completed += async (sender, eventArgs) => {
				if (eventArgs.IsAuthenticated) {
					// Use eventArgs.Account to do wonderful things
					App.CompleteLogin(eventArgs.Account.Properties["access_token"]);
					await App.PerformSuccessfulLoginAction();

				} else {
					// The user cancelled
				}
			};

			activity.StartActivity (auth.GetUI(activity));
		}
	}
}

