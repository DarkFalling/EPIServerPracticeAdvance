using AlloyTraining.Models.Pages;
using AlloyTraining.Models.Rss;

namespace AlloyTraining.Models.ViewModels
{
    public class RssReaderPageViewModel : IPageViewModel<RssReaderPage>
    {
        public RssReaderPage CurrentPage { get; set; }
        public RssFeed RssFeed { get; set; }
        public string CachedTime { get; set; }

        public RssReaderPageViewModel(RssReaderPage currentPage)
        {
            CurrentPage = currentPage;
        }
    }
}