using Crypto.model;
using Crypto.services;
using System;
using System.IO.IsolatedStorage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Crypto
{
    public sealed partial class MainPage : Page
    {
        private CryptoCoinData[] _cryptoCoinList = Array.Empty<CryptoCoinData>();

        private readonly APIService _APIService = new APIService();

        public MainPage()
        {
            InitializeComponent();
            getCoinList();
            sortCoinList();
            showCoinsTop();
        }

        private void getCoinList()
        {
            try
            {
                _cryptoCoinList = _APIService.getCoinList();
            }
            catch (Exception e)
            {
                errorText.Text = e.Message;
            }
        }

        private void sortCoinList()
        {
            Array.Sort(_cryptoCoinList,
                      delegate (CryptoCoinData x, CryptoCoinData y)
                      { return x.rank.CompareTo(y.rank); });
        }

        private void showCoinsTop()
        {
            int number = 1;
            int topLength = 10;
            if (_cryptoCoinList.Length < 10)
            {
                topLength = _cryptoCoinList.Length;
            }
            for (int i = 0; i < topLength; i++)
            {
                TextBlock coinInfo = new TextBlock()
                {
                    Text = $"{number++}. {_cryptoCoinList[i]}"
                };
                coinsTopPanel.Children.Add(coinInfo);
            }
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
                _ = myFrame.Navigate(typeof(MainPage));

            }
            else if (convert.IsSelected)
            {
                _ = myFrame.Navigate(typeof(Okno));
            }
            else if (detailed_view.IsSelected)
            {
                _ = myFrame.Navigate(typeof(detalied_view));
            }
            else if (setting_view.IsSelected)
            {
                _ = myFrame.Navigate(typeof(setting));
            }
           
        }

      
    }
}
