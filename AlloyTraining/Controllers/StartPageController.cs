using System.Web.Mvc;
using EPiServer.Core;
using AlloyTraining.Models.Pages;
using AlloyTraining.Models.ViewModels;

namespace AlloyTraining.Controllers
{
    public class StartPageController : PageControllerBase<StartPage>
    {
        private string _uiInfoSearchInactiveMessage = "No search page is specified in Settings on the start page...";
        public ActionResult Index(StartPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            DefaultPageViewModel<StartPage> model = new DefaultPageViewModel<StartPage>(currentPage);

            if (PageReference.IsNullOrEmpty(currentPage.SearchPageLink))
            {
                model.IsSearchPageSet = false;
                model.SearchNotActiveMessage = _uiInfoSearchInactiveMessage;
            }
            return View(model);
        }
    }
}