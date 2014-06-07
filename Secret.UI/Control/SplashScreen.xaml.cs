using System.Windows.Controls;

namespace Secret.UI.Control
{
    public partial class SplashScreen : UserControl
    {
        public SplashScreen()
        {
            InitializeComponent();
            this.LayoutRoot.Width = System.Windows.Application.Current.Host.Content.ActualWidth;
            this.LayoutRoot.Height = System.Windows.Application.Current.Host.Content.ActualHeight;
        }

    }
}
