using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using AlloyTraining.Models.Blocks;
using EPiServer.Web;
using AlloyTraining.Business.Comments;
using EPiServer;

namespace AlloyTraining.Models.Pages
{
    [ContentType(DisplayName = "NewsPage", GUID = "510d55a6-b159-4ecb-85ab-1da68b01e937", Description = "")]
    public class NewsPage : StandardPage, ICommentableContent
    {

        [Display(
            Name = "Main Listing",
            Description = "A listing of news pages",
            GroupName = SystemTabNames.Content,
            Order = 315)]
        public virtual ListingBlock MainListing { get; set; }

        [UIHint(UIHint.BlockFolder)]
        [Display(
            Name = "Comment folder",
            Description = "Folder used as root for comments. If not set, comment function will be disabled",
            GroupName = SystemTabNames.Settings,
            Order = 500)]
        public virtual ContentReference CommentFolder { get; set; }

        public void ConfigureCommentSettings()
        {
            if (!ContentReference.IsNullOrEmpty(this.CommentFolder))
                return;

            var contentRepository = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<IContentRepository>();
            var newCommentFolder = CommentHandler.AddNewCommentFolder(contentRepository, this);
            if (newCommentFolder == null)
                return;

            var editableNewsPage = this.CreateWritableClone() as NewsPage;

            editableNewsPage.CommentFolder = newCommentFolder.ContentLink;

            contentRepository.Save(editableNewsPage, EPiServer.DataAccess.SaveAction.Publish, EPiServer.Security.AccessLevel.Publish);
        }
    }
}