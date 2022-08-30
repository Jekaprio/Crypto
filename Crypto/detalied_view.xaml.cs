using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace Crypto
{

    public sealed partial class detalied_view : Page
    {
        public detalied_view()
        {
            InitializeComponent();
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
