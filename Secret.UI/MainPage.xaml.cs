using Microsoft.Phone.Controls;
using System;
using System.ComponentModel;
using System.Windows.Controls.Primitives;

namespace Secret.UI
{

    public partial class MainPage : PhoneApplicationPage
    {
        Popup myPopup;
        Popup exitPopup;
        static System.Windows.Threading.DispatcherTimer dt = new System.Windows.Threading.DispatcherTimer() { Interval = TimeSpan.FromMilliseconds(1000) };
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
            myPopup = new Cnljli.WPViewModel.UIElement.SplashScreen(new Secret.UI.Control.SplashScreen(), () =>
            {
                System.Threading.Thread.Sleep(500);
                myPopup.IsOpen = false;
            }).GetInstant;

            exitPopup = Cnljli.WPViewModel.UIElement.InfoPopup.GetInfoPopup("再按一次返回键退出", (p, g) =>
            {
                g.Margin = new System.Windows.Thickness(-90, -60, 0, 0);
                this.main.Children.Add(p);
            });
            dt.Tick += ((seder, e) =>
            {
                exitPopup.IsOpen = false;
            });
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            e.Cancel = true;
            if (exitPopup.IsOpen)
            {
                dt.Stop();
                App.Current.Terminate();
            }
            else
            {
                dt.Start();
                exitPopup.IsOpen = true;
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Control/DataList.xaml?tag=" + (sender as ButtonBase).Tag.ToString(), UriKind.Relative));
        }
    }
}