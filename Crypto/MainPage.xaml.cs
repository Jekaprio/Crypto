using Crypto.model;
using Newtonsoft.Json;
using RestSharp;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Crypto
{
    public sealed partial class MainPage : Page
    {
        private CryptoCoinData[] _cryptoCoinList = Array.Empty<CryptoCoinData>();

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
                string url = "https://api.coincap.io/v2/assets";
                RestClient client = new RestClient(url);
                RestRequest request = new RestRequest();
                RestResponse response = client.Get(request);
                _cryptoCoinList = JsonConvert.DeserializeObject<CryptoCoinList>
                                       (response.Content.ToString()).data;
            }
            catch (Exception)
            {
                errorText.Text = "Error initialization: Check your the Internet connection";
            }
        }

        private void sortCoinList()
        {
            Array.Sort(_cryptoCoinList,
                      delegate (CryptoCoinData x, CryptoCoinData y) 
                      { return x.rank.CompareTo(y.rank);});
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
                    Text = $"{number++}.{_cryptoCoinList[i].name}"

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
            if (about_crypto.IsSelected)
            {
                _ = myFrame.Navigate(typeof(MainPage));
            }
            else if (convert.IsSelected)
            {
                _ = myFrame.Navigate(typeof(Okno));
            }
            /*else if ()
            {

            }*/
        }
    }


}
