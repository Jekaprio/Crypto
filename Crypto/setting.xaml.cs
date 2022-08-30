using System.Diagnostics;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


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

        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            if (sender is ToggleSwitch toggleSwitch)
            {
                if (toggleSwitch.IsOn == false)
                {
                    MessageDialog dialog = new MessageDialog("Enlgish");
                    _ = dialog.ShowAsync();

                }
                else if (toggleSwitch.IsOn == true)
                {
                    MessageDialog dialog = new MessageDialog("Українська");
                    _ = dialog.ShowAsync();
                }
            }

        }

        private void ToggleSwitch_Toggled_1(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            {
                if (toggleSwitch.IsOn == false)
                {
                    RequestedTheme = ElementTheme.Dark;
                    MessageDialog dialog = new MessageDialog("Change to Dark");
                    _ = dialog.ShowAsync();
                   

                }
                else if (toggleSwitch.IsOn == true)
                {
                    RequestedTheme = ElementTheme.Light;
                    MessageDialog dialog = new MessageDialog("Change to Light");
                    _ = dialog.ShowAsync();
                }
            }


        }

      
    }
}

