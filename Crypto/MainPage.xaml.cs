using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection.Metadata;
using static System.Net.WebRequestMethods;
using Crypto.model;
using System.Text.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;
using System.Reflection;
using System.Text.Json.Serialization;
using Windows.Devices.Enumeration;
using Windows.UI.Core;

namespace Crypto
{
    public sealed partial class MainPage : Page
    {
        private CryptoCoinData[] _cryptoCoinList;
        public MainPage()
        {
            this.InitializeComponent();

            this.getCoinList();
            this.sortCoinList();
            this.showCoinsTop();
        }

        private void getCoinList()
        {
            string url = "https://api.coincap.io/v2/assets";
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.Get(request);
            this._cryptoCoinList = JsonConvert.DeserializeObject<CryptoCoinList>
                                   (response.Content.ToString()).data;
        }

        private void sortCoinList()
        {
            Array.Sort(this._cryptoCoinList,
                      delegate (CryptoCoinData x, CryptoCoinData y) { return x.rank.CompareTo(y.rank); });
            this._cryptoCoinList = this._cryptoCoinList.Skip(0).Take(10).ToArray();
        }

        private void showCoinsTop()
        {
            foreach (var coin in this._cryptoCoinList) 
            {
                TextBox coinInfo = new TextBox();
                coinInfo.Text = coin.name;
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
