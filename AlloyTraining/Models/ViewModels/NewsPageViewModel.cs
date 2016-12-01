using AlloyTraining.Models.Blocks;
using AlloyTraining.Models.Pages;
using System.Collections.Generic;

namespace AlloyTraining.Models.ViewModels
{

    public class NewsPageViewModel : IPageViewModel<NewsPage>
    {
        public NewsPage CurrentPage { get; set; }
        public IEnumerable<PostedComment> CommentList { get; set; }

        public NewsPageViewModel(NewsPage currentPage)
        {
            CurrentPage = currentPage;
        }
    }
}