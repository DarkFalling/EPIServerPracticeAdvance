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
    public class FAQPageController : PageControllerBase<FAQPage>
    {
        public ActionResult Index(FAQPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */
            var contentRepository = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<IContentRepository>();
            currentPage.FAQItems = contentRepository.GetChildren<FAQItem>(currentPage.ContentLink).ToList();
            DefaultPageViewModel<FAQPage> model = new DefaultPageViewModel<FAQPage>(currentPage);

            return View(model);
        }

        public ActionResult Submit(FAQPage currentPage, string question)
        {
            var contentRepository = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<IContentRepository>();

            FAQItem fi = contentRepository.GetDefault<FAQItem>(currentPage.ContentLink);

            fi.Name = string.Format("Question: {0}", question);
            fi.Question = question;
            contentRepository.Save(fi, EPiServer.DataAccess.SaveAction.Save, EPiServer.Security.AccessLevel.Read);

            DefaultPageViewModel<FAQPage> model = new DefaultPageViewModel<FAQPage>(currentPage);

            return View("Index", model);

        }
    }
}