using System;

using Xamarin.Forms;

namespace XamaGram
{
	public abstract class BaseContentPage : ContentPage
	{
		protected BaseContentPage()
		{
			_ActivityIndicator = new ActivityIndicator();
			_ActivityIndicator.IsRunning = true;
			_ActivityIndicator.Color = Color.Blue;
		}

		protected async override void OnAppearing ()
		{
			base.OnAppearing ();

			if (!IsAuthenticated) {
				var loginPage = new LoginPage();
				if (Device.OS == TargetPlatform.Android) {
					loginPage.Disappearing += delegate {
						this.OnAppearing();
					};
				}
				await Navigation.PushModalAsync(loginPage);
			}
		}

		protected bool IsAuthenticated
		{
			get { return App.IsAuthenticated; }
		}

		private readonly ActivityIndicator _ActivityIndicator;
		protected ActivityIndicator ActivityIndicator 
		{
			get { 
				return _ActivityIndicator;
			}
		}
	}
}


