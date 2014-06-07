using Microsoft.Phone.Controls;

namespace Secret.UI.Control
{
    public partial class DataList : PhoneApplicationPage
    {
        public DataList()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            Secret.Domain.ListEnum listenum;
            if (e.IsNavigationInitiator 
                &&e.NavigationMode== System.Windows.Navigation.NavigationMode.New
                && System.Enum.TryParse<Secret.Domain.ListEnum>(this.NavigationContext.QueryString["tag"], out listenum))
            {
                this.DataContext = new Secret.Domain.DataListModel(listenum);
            }
        }

        private void GestureListener_DoubleTap(object sender, GestureEventArgs e)
        {
            Secret.Domain.Data obj = ((sender as System.Windows.Controls.Border).DataContext as Secret.Domain.Data);
            if (obj != null)
            {
                this.NavigationService.Navigate(new System.Uri("/Control/Detail.xaml?tag=" + obj.id, System.UriKind.Relative));
            }
        }
    }
}