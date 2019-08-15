using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ControlLoadingPerformance.Shared.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ControlLoadingPerformance.Shared.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageWith128 : Page
    {
        private ControlRendererViewModel viewModel;

        public PageWith128()
        {
            this.InitializeComponent();
            viewModel = new ControlRendererViewModel(16);
            DataContext = viewModel;
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("ReportButton was click");
            viewModel.ReportButtonClick(sender as Button);
        }
    }
}
