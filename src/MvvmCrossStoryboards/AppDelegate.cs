using Foundation;
using MvvmCross.Platforms.Ios.Core;
using UIKit;

namespace MvvmCrossStoryboards
{
    [Register(nameof(AppDelegate))]
    public class AppDelegate : MvxApplicationDelegate<Setup, App>
    {
        private static void Main(string[] args)
        {
            UIApplication.Main(args, null, nameof(AppDelegate));
        }
    }
}