using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using AlloyTraining.Models.Pages;
using AlloyTraining.Models.ViewModels;

namespace AlloyTraining.Controllers
{
    public class NewsPageController : PageControllerBase<NewsPage>
    {
        [ContentOutputCache]
        public ActionResult Index(NewsPage currentPage)
        {
             /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */
            DefaultPageViewModel<NewsPage> model = new DefaultPageViewModel<NewsPage>(currentPage);
            return View(model);
        }
    }
}