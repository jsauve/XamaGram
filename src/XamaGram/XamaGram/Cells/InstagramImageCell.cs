using System;
using Xamarin.Forms;

namespace XamaGram
{
	public class InstagramImageCell : ViewCell
	{
		public InstagramImageCell()
		{
			var image = new Image
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
			};
			image.WidthRequest = image.HeightRequest = 320;

			image.SetBinding(Image.SourceProperty, new Binding("Images.StandardResolution.Url"));

			var label = new Label();
			label.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
			label.SetBinding(Label.TextProperty, new Binding("User.Username"));

			AbsoluteLayout absLayout = new AbsoluteLayout();
			absLayout.Children.Add(image, new Point(0, 0));
			absLayout.Children.Add(label, new Point(5, 5));

			View = absLayout;
		}
	}
}

