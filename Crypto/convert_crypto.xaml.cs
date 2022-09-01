using Crypto.model;
using Crypto.services;
using System;
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

            crypto_list1.ItemsSource = _cryptoCoinList;
            crypto_list2.ItemsSource = _cryptoCoinList;
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

        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            getCoinList();
            CryptoCoinData selectedCoin = _cryptoCoinList[crypto_list1.SelectedIndex];
            CryptoCoinData selectedCoin2 = _cryptoCoinList[crypto_list2.SelectedIndex];
            float quantity = float.Parse(QuantityList.Text.ToString());
            float result = convertCoin(selectedCoin.name, selectedCoin2.name, quantity);
            Finish.Text = $"{quantity} {selectedCoin.name} =  {result} {selectedCoin2.name}";
        }

        private float convertCoin(string coinName, string secondCoinName, float number)
        {
            float coinUsdPrice = Array.Find(_cryptoCoinList, item => item.name == coinName).priceUsd;
            float secondCoinUsdPrice = Array.Find(_cryptoCoinList, item => item.name == secondCoinName).priceUsd;
            float coinFullPrice = coinUsdPrice * number;
            return coinFullPrice / secondCoinUsdPrice;
        }
    }
}
