using CommunityToolkit.Mvvm.ComponentModel;
using MauiAppCollectionViewBug.Models;
using System.Collections.ObjectModel;

namespace MauiAppCollectionViewBug.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        #region Dispatcher
        [ObservableProperty]
        public partial IDispatcher? Dispatcher { get; set; }

        #endregion

        #region Properties

        [ObservableProperty]
        public partial ObservableCollection<Short> Shorts { get; set; } = [];

        #endregion

        #region Ctor

        public MainPageViewModel(IDispatcher dispatcher)
        {
            Dispatcher = dispatcher;
            List<Short> shorts = [];
            shorts.Add(new() { Name = "Short 1", Shorts = [] });
            shorts.Add(new() { Name = "Short 2", Shorts = [] });
            shorts.Add(new() { Name = "Short 3", Shorts = [] });
            shorts.Add(new() { Name = "Short 4", Shorts = [] });
            Dispatcher.Dispatch(() => Shorts = [.. shorts]);
        }

        #endregion
    }
}
