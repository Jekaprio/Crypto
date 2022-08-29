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


namespace Crypto
{

    public sealed partial class detalied_view : Page
    {
        public detalied_view()
        {
            this.InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;
            if (about_crypto.IsSelected)
            {
                _ = FrameDetalied.Navigate(typeof(MainPage));
            }
            else if (convert.IsSelected)
            {
                _ = FrameDetalied.Navigate(typeof(Okno));
            }
            else if (setting_view.IsSelected)
            {
                _ = FrameDetalied.Navigate(typeof(setting));
            }
            else if (detailed_view.IsSelected)
            {
                _ = FrameDetalied.Navigate(typeof(detalied_view));
            }
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;
        }
    }
}
