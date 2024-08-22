using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace CollectionViewBug.ViewModels
{
    internal partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<string> events = ["Item 1", "Item 2", "Item 3"];
    }
}
