using System;
using System.IO;
using System.Reflection;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace SimpleTodo.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            var executingPath = Directory.GetCurrentDirectory();

            if (platform == Platform.Android)
            {
                return ConfigureApp.Android
                    .LogDirectory(executingPath)
                    .InstalledApp("com.tafuji.SimpleTodo")
                    .EnableLocalScreenshots()
                    .StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}