using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace HelloXamarin.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android.EnableLocalScreenshots().InstalledApp("com.tafuji.HelloXamarin").StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}