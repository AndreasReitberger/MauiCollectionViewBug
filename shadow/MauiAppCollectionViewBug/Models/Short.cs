using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiAppCollectionViewBug.Models
{
    public partial class Short : ObservableObject
    {
        #region Properties

        [ObservableProperty]
        public partial string Name { get; set; } = string.Empty;

        [ObservableProperty]
        public partial List<string> Shorts { get; set; } = [];

        #endregion
    }
}
