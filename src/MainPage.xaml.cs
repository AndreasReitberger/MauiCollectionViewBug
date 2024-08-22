using CollectionViewBug.ViewModels;
using System.Collections.ObjectModel;

namespace CollectionViewBug
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
    }

}
