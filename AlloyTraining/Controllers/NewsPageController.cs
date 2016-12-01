using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using AlloyTraining.Models.Pages;
using AlloyTraining.Models.ViewModels;
using System;
using AlloyTraining.Business.Comments;

namespace AlloyTraining.Controllers
{
    public class NewsPageController : PageControllerBase<NewsPage>
    {
        [ContentOutputCache]
        public ActionResult Index(NewsPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */
            NewsPageViewModel model = new NewsPageViewModel(currentPage)
            {
                CommentList = handler.LoadComments(currentPage.CommentFolder),
                HasCommentPublishAccess = handler.CurrentUserHasCommentPublishAccess(currentPage.CommentFolder),
                CommentFolderIsSet = handler.CommentFolderIsSet(currentPage.CommentFolder)
            };

            return View(model);
        }
        private CommentHandler handler;
        public NewsPageController(CommentHandler handler)
        {
            this.handler = handler;
        }

        [HttpPost]
        public ActionResult Create(NewsPage currentPage, string commentatorName, string text)
        {
            handler.AddComment(currentPage.CommentFolder, commentatorName, text, DateTime.Now);
            return RedirectToAction("Index");
        }
    }
}