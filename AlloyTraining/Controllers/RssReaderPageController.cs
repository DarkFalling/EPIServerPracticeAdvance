using System.Web.Mvc;
using EPiServer.Web.Mvc;
using AlloyTraining.Models.Pages;
using AlloyTraining.Models.Rss;
using AlloyTraining.Models.ViewModels;

namespace AlloyTraining.Controllers
{
    public class RssReaderPageController : PageController<RssReaderPage>
    {
        public ActionResult Index(RssReaderPage currentPage)
        {
            var rssFeed = new RssFeed(currentPage.RssUrl.ToString(), currentPage.MaxCount);

            var model = new RssReaderPageViewModel(currentPage);
            model.RssFeed = rssFeed;

            return View(model);
        }
    }
}