using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using ControlLoadingPerformance.Shared.Views;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ControlLoadingPerformance
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string lastItem;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private Type GetPageClass(string navItemContent)
        {
            switch (navItemContent)
            {
                case "Page 1": return typeof(PageWith1);
                case "Page 2": return typeof(PageWith16);
                case "Page 3": return typeof(PageWith64);
                default: return null;
            }
        }

        private void NavigationView_OnItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked) return;
            var item = args.InvokedItem as string;
            if (item == null || item == lastItem)
                return;
            var clickedView = GetPageClass(item);
            if (!NavigateToView(clickedView)) return;
            lastItem = item;
        }

        private bool NavigateToView(Type clickedView)
        {
            if (clickedView == null)
            {
                return false;
            }

            ContentFrame.Navigate(clickedView, null, new EntranceNavigationTransitionInfo());
            return true;
        }

        private void ContentFrame_OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (ContentFrame.CanGoBack)
                ContentFrame.GoBack();
        }
    }
}
