# XamaGram
A Xamarin.Forms demo that uses the Instagram API as a data source.
![Android_iOS_Combined](https://rawgit.com/jsauve/XamaGram/master/screenshots/Android_iOS_combined.png)

## Requirements
* Xamarin.iOS (I'm using 8.10.0.267)
* Xamarin.Android (I'm using 5.1.0.115)
* Xamarin.Forms 1.4 (I'm using 1.4.2.6359)
* Xamarin Studio or Visual Studio w/ Xamarin extensions (I used Xamarin Studio for this)

## How to setup
You'll need an Instagram account. Login via the web and go to https://instagram.com/developer/clients/manage/
There you can create a new set of client credentials for your app.

In the App.cs in the XamaGram project, you'll see a section where you can enter the Instagram Client ID and Redirect URL you just created.

    XamarinAuthSettings = 
        new OAuthSettings(
            clientId: "",
            scope: "basic",
            authorizeUrl: "https://api.instagram.com/oauth/authorize/",
            redirectUrl: "");
            
That's it! You should now be able to build your app for either iOS or Android. The first time you login, Instagram will prompt you to authorize the app. This only happens once and occurs for any app that uses the Instagram API.
