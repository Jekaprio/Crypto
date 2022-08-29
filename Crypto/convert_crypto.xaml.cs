using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace Crypto
{

    public sealed partial class Okno : Page
    {
        public Okno()
        {
            InitializeComponent();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (about_crypto.IsSelected)
            {
                _ = Frame_Convert.Navigate(typeof(MainPage));
            
            }
            else if (convert.IsSelected)
            {
                _ = Frame_Convert.Navigate(typeof(Okno));
               
            }
            /*else if ()
            {

            }*/
        }
    }


}
