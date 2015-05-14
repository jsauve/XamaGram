# XamaGram
A Xamarin.Forms demo that uses the Instagram API as a data source. Login with any Instagram account! 16 hours of development is all it took to get the app to its initial state of seven functional screens.

## Screenshots
![Android_iOS_Combined](https://rawgit.com/jsauve/XamaGram/master/screenshots/Android_iOS_combined.png)

## Video
http://bit.ly/1AXNjpO

## Requirements
* Xamarin.iOS (I'm using 8.10.0.267)
* Xamarin.Android (I'm using 5.1.0.115)
* Xamarin.Forms 1.4 (I'm using 1.4.2.6359)
* Xamarin Studio or Visual Studio w/ Xamarin extensions (I used Xamarin Studio for this)

## How to setup
You'll need an Instagram account. Login via the web and go to https://instagram.com/developer/clients/manage/.
There you can create a new set of client credentials for your app.

In the App.cs in the XamaGram project, you'll see a section where you can enter the Instagram Client ID and Redirect URL you just created.

    XamarinAuthSettings = 
        new OAuthSettings(
            clientId: "[your client id]",
            scope: "basic",
            authorizeUrl: "https://api.instagram.com/oauth/authorize/",
            redirectUrl: "[your redirect url]");
            
That's it! You should now be able to build your app for either iOS or Android. The first time you login, Instagram will prompt you to authorize the app. This only happens once and occurs for any app that uses the Instagram API.

## Attribution
This project uses a portion of the InstaSharp project, a C# wrapper for the Instagram API. I found that their client implementation wasn't working for me, so I just borrowed their model classes and wrote my own simple lightweight HttpClient implementation for the Instagram API. InstaSharp source can be found here: https://github.com/InstaSharp/InstaSharp

## Caveats and known issues
* At this time, the app does not take advantage of pagination in the Instagram API, so it only loads of max of 30 images in each list (which is the maximum page size that Instagram prefers API consumers to adhere to).
* The image widths don't go the screen edges on some devices, and may be cut off on smaller devices. This will be remedied when I add some of the great Xamarin.Forms extensions from: https://github.com/XLabs/Xamarin-Forms-Labs
* The app currently does not store the Instagram API token in the device keychain, so you have to login each time the app starts.
* The app does not provide a logout function, so there is no way to logout besides "killing" the app.

## Roadmap
* Add proper exception handling.
* Add network connectivity checking.
* Add Xamarin Insights integration point (optionally enabled).
* Add pagination to relevant InstagramClient methods to support more than 30 images in each list.
* Add pull-to-refresh to relevant screens.
* Add an image detail page for displaying descriptions, likes, comments, time since post, etc.
* Add dropshadow to overlaid image labels (using Xamarin-Forms-Labs extension).
* Add the Xamarin-Forms-Labs extension that allows device-specific screen width detection at runtime.
* Add optional grid layouts for display of followers/following and image lists.
* Add navigation of followers/following user graph by extending the ProfilePage to be shown for users other than just the authenticated user. May involve a custom BindableProperty on ProfilePage, to facilitate use within a DataTemplate.
