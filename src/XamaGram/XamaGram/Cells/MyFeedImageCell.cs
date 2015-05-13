using System;
using Xamarin.Forms;

namespace XamaGram
{
	public class MyFeedImageCell : ViewCell
	{
		public MyFeedImageCell()
		{
			var image = new Image
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
			};
			image.WidthRequest = image.HeightRequest = 320;

			image.SetBinding(Image.SourceProperty, new Binding("Images.StandardResolution.Url"));

			View = image;
		}
	}
}

