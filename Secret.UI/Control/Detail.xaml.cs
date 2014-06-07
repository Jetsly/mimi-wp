using Microsoft.Phone.Controls;

namespace Secret.UI.Control
{
    public partial class Detail : PhoneApplicationPage
    {
        public Detail()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            int id = 0;
            if (e.IsNavigationInitiator&&int.TryParse(this.NavigationContext.QueryString["tag"], out id))
            {
                this.DataContext = new Secret.Domain.DetailModel(id);
            }
        }
    }
}