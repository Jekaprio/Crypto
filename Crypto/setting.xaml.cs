using System.Diagnostics;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Abp.Localization;
using System;
using Windows.UI.Xaml.Navigation;

namespace Crypto
{

    public sealed partial class setting : Page
    {
        public setting()
        {
            InitializeComponent();
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
                _ = FrameSetting.Navigate(typeof(MainPage));
            }
            else if (convert.IsSelected)
            {
                _ = FrameSetting.Navigate(typeof(Okno));
            }
            else if (detailed_view.IsSelected)
            {
                _ = FrameSetting.Navigate(typeof(detalied_view));
            }
            else if (setting_view.IsSelected)
            {
                _ = FrameSetting.Navigate(typeof(setting));
            }
        }

        private void ToggleSwitch_Toggled_1(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            {
                if (toggleSwitch.IsOn == false)
                {
                    RequestedTheme = ElementTheme.Dark;
                }
                else if (toggleSwitch.IsOn == true)
                {
                    RequestedTheme = ElementTheme.Light;
                }
            }
        }
    }
}

