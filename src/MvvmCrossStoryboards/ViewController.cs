using System;
using Foundation;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;

namespace MvvmCrossStoryboards
{
    [Register(nameof(ViewController))]
    [MvxFromStoryboard("Storyboard")]
    [MvxRootPresentation]
    public partial class ViewController : MvxViewController<ViewModel>
    {
        public ViewController(IntPtr handle) : base(handle)
        {
            /* Required constructor */
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = CreateBindingSet();
            set.Bind(_label).To(vm => vm.Text);
            set.Apply();
        }
    }
}