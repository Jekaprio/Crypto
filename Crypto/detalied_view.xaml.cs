using Crypto.model;
using Crypto.services;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace Crypto
{

    public sealed partial class detalied_view : Page
    {
        private CryptoCoinData[] _cryptoCoinList = Array.Empty<CryptoCoinData>();

        private readonly APIService _APIService = new APIService();
        public detalied_view()
        {
            InitializeComponent();
            getCoinList();

            searchCoin.ItemsSource = _cryptoCoinList;
        }

        private void getCoinList()
        {
            _cryptoCoinList = _APIService.getCoinList();
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

        private void searchCoin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            getCoinList();
            CryptoCoinData coinData = _cryptoCoinList[searchCoin.SelectedIndex];
            Enter_price.Text = coinData.priceUsd.ToString();
            Enter_amount.Text = coinData.supply.ToString("0.00");
            Enter_change.Text = coinData.changePercent24Hr.ToString();
            MarketsData.MarketData[] coinMarkets = _APIService.getMarketsList(coinData.id);

            string marketsList = "";
            // Make this because for BTC Zaif(Markets) returns > 1 time
            int k = 5;
            for (int j = 0; j < k; j++)
            {
                MarketsData.MarketData i = coinMarkets[j];
                if (marketsList.Contains(i.exchangeId)) { k++; continue; }
                marketsList += i.exchangeId + ", ";

            }
            _ = marketsList.TrimEnd(',');
            Enter_buyin.Text = marketsList;
        }
    }
}
