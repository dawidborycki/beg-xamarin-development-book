#region Using

using System.Collections.Generic;
using UIKit;

#endregion

namespace Navigation.PageBased
{
    public class ModelController : UIPageViewControllerDataSource
    {
        #region Fields

        readonly List<KeyValuePair<string, UIColor>> pageData;

        #endregion

        #region Constructor

        public ModelController()
		{
			pageData = new List<KeyValuePair<string, UIColor>>
    		{
    			new KeyValuePair<string, UIColor>("Red", UIColor.Red),
    			new KeyValuePair<string, UIColor>("Green", UIColor.Green),
    			new KeyValuePair<string, UIColor>("Blue", UIColor.Blue)
    		};
		}

        #endregion

        #region Methods (Public)

        public DataViewController GetViewController(int index, UIStoryboard storyboard)
        {
            if (index >= pageData.Count)
                return null;

            // Create a new view controller and pass suitable data.
            var dataViewController = (DataViewController)storyboard.InstantiateViewController("DataViewController");
            dataViewController.DataObject = pageData[index];

            return dataViewController;
        }

        public int IndexOf(DataViewController viewController)
        {
            return pageData.IndexOf(viewController.DataObject);
        }

        #endregion

        #region Page View Controller Data Source

        public override UIViewController GetNextViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
        {
            int index = IndexOf((DataViewController)referenceViewController);

            if (index == -1 || index == pageData.Count - 1)
                return null;

            return GetViewController(index + 1, referenceViewController.Storyboard);
        }

        public override UIViewController GetPreviousViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
        {
            int index = IndexOf((DataViewController)referenceViewController);

            if (index == -1 || index == 0)
                return null;

            return GetViewController(index - 1, referenceViewController.Storyboard);
        }

        #endregion
    }
}
