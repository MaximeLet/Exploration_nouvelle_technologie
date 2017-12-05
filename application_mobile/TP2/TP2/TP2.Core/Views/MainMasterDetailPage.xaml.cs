using Prism.Navigation;
using Xamarin.Forms;

namespace TP2.Core.Views
{
    public partial class MainMasterDetailPage : MasterDetailPage, IMasterDetailPageOptions
    {
        public MainMasterDetailPage()
        {
            InitializeComponent();
        }

        public bool IsPresentedAfterNavigation => Device.Idiom != TargetIdiom.Phone;
    }
}
