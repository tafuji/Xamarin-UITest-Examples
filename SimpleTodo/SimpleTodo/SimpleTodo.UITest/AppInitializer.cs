using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace SimpleTodo.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android.InstalledApp("com.tafuji.SimpleTodo").EnableLocalScreenshots().StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}