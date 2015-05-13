using System;

using Xamarin.Forms;

namespace XamaGram
{
	// Will be implemented in the future to provide image details.
	public class ImageDetailPage : ContentPage
	{
		public ImageDetailPage()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


