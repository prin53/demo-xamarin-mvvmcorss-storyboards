using MvvmCross.ViewModels;

namespace MvvmCrossStoryboards
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();

            RegisterAppStart<ViewModel>();
        }
    }
}