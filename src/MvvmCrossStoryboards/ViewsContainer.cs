using System;
using System.Reflection;
using Foundation;
using MvvmCross.Exceptions;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.ViewModels;
using UIKit;

namespace MvvmCrossStoryboards
{
    public class ViewsContainer : MvxIosViewsContainer
    {
        private const string PadPostfix = ".Pad";
        private const string PhonePostfix = ".Phone";
        private const string StoryboardResourceType = "storyboardc";

        public override IMvxIosView CreateViewOfType(Type viewType, MvxViewModelRequest request)
        {
            var attribute = viewType.GetCustomAttribute<MvxFromStoryboardAttribute>();

            if (attribute == null || string.IsNullOrWhiteSpace(attribute.StoryboardName))
            {
                return base.CreateViewOfType(viewType, request);
            }

            try
            {
                var isPad = UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad;
                var postfix = isPad ? PadPostfix : PhonePostfix;
                var realStoryboardName = attribute.StoryboardName + postfix;
                var path = NSBundle.MainBundle.PathForResource(realStoryboardName, StoryboardResourceType);
                var storyboardName = path == null ? attribute.StoryboardName : realStoryboardName;
                var storyboard = UIStoryboard.FromName(storyboardName, null);
                var viewController = storyboard.InstantiateViewController(viewType.Name);

                return (IMvxIosView) viewController;
            }
            catch (Exception exception)
            {
                throw new MvxException(
                    "Loading view of type {0} from storyboard {1} failed: {2}",
                    viewType.Name,
                    attribute.StoryboardName,
                    exception.Message
                );
            }
        }
    }
}