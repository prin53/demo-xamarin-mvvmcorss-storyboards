using MvvmCross.ViewModels;

namespace MvvmCrossStoryboards
{
    public class ViewModel : MvxViewModel
    {
        public string Text { get; }

        public ViewModel()
        {
            Text = "Hello!";
        }
    }
}