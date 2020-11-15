using MvvmCross.Platforms.Ios.Core;
using MvvmCross.Platforms.Ios.Views;

namespace MvvmCrossStoryboards
{
    public class Setup : MvxIosSetup<App>
    {
        protected override IMvxIosViewsContainer CreateIosViewsContainer()
        {
            return new ViewsContainer();
        }
    }
}