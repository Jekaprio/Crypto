using RestSharp;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Newtonsoft.Json;
using Crypto.model;

namespace Crypto
{
    public sealed partial class MainPage : Page
    {
        private CryptoCoinData[] _cryptoCoinList = Array.Empty<CryptoCoinData>();

        public MainPage()
        {
            this.InitializeComponent();
            this.getCoinList();
            this.sortCoinList();
            this.showCoinsTop();    
        }

        private void getCoinList()
        {
            try
            {
                string url = "https://api.coincap.io/v2/assets";
                var client = new RestClient(url);
                var request = new RestRequest();
                var response = client.Get(request);
                this._cryptoCoinList = JsonConvert.DeserializeObject<CryptoCoinList>
                                       (response.Content.ToString()).data;
            }
            catch (Exception ex)
            {
                errorText.Text = "Error initialization: Check your the Internet connection";
            }
        }

        private void sortCoinList()
        {
            Array.Sort(this._cryptoCoinList,
                      delegate (CryptoCoinData x, CryptoCoinData y) { return x.rank.CompareTo(y.rank); });
        }

        private void showCoinsTop()
        {
            var topLength = 10;
            if(this ._cryptoCoinList.Length <10)
            {
                topLength = this._cryptoCoinList.Length;
            }
            for (var i = 0; i < topLength; i++)
            {
                TextBox coinInfo = new TextBox();
                coinInfo.Text = this._cryptoCoinList[i].name;
                coinsTopPanel.Children.Add(coinInfo);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (home.IsSelected)
            {
                myFrame.Navigate(typeof(MainPage));
                TitleTextBlock.Text = "Home";
            }
           /* else if ()
            {

            }
            else if ()
            {

            }*/
        }
    }


}
