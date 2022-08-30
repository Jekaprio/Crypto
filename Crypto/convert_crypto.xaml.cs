using Crypto.model;
using Crypto.services;
using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace Crypto
{

    public sealed partial class Okno : Page
    {
        private CryptoCoinData[] _cryptoCoinList = Array.Empty<CryptoCoinData>();

        private readonly APIService _APIService = new APIService();
        public Okno()
        {
            InitializeComponent();
            getCoinList();
        }

       

        private void getCoinList()
        {
            
         _cryptoCoinList = _APIService.getCoinList();


            crypto_list1.ItemsSource = _cryptoCoinList;

            crypto_list2.ItemsSource = _cryptoCoinList;

            
        }
       

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;
            
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;
            if (about_crypto.IsSelected)
            {
                _ = Frame_Convert.Navigate(typeof(MainPage));
            }
            else if (convert.IsSelected)
            {
                _ = Frame_Convert.Navigate(typeof(Okno));
            }
            else if (detailed_view.IsSelected)
            {
                _ = Frame_Convert.Navigate(typeof(detalied_view));
            }
            else if (setting_view.IsSelected)
            {
                _ = Frame_Convert.Navigate(typeof(setting));
            }
        }
    }
}
