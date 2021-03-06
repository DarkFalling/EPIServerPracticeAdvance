﻿using AlloyTraining.Models.Blocks;
using AlloyTraining.Models.Pages;
using EPiServer;
using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlloyTraining.Business.Comments
{
    public class CommentHandler
    {
        private IContentRepository _contentRepository;

        public CommentHandler(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public void AddComment(ContentReference commentFolderReference, string name, string text, DateTime date)
        {
            PostedComment newCommentBlock = _contentRepository.GetDefault<PostedComment>(commentFolderReference);

            newCommentBlock.Text = text;
            newCommentBlock.Date = date;
            newCommentBlock.CommentatorName = name;
            IContent newCommentBlockInstance = newCommentBlock as IContent;
            newCommentBlockInstance.Name = name;

            _contentRepository.Save(newCommentBlockInstance, EPiServer.DataAccess.SaveAction.Publish, EPiServer.Security.AccessLevel.Publish);
        }

        public IEnumerable<PostedComment> LoadComments(ContentReference commentFolderReference)
        {
            if (ContentReference.IsNullOrEmpty(commentFolderReference))
                return null;

            var filterContentForVisitor = new EPiServer.Filters.FilterContentForVisitor(
                EPiServer.Framework.Web.TemplateTypeCategories.MvcPartialView,
                string.Empty);

            var allComments = _contentRepository.GetChildren<IContent>(commentFolderReference).ToList<IContent>();

            filterContentForVisitor.Filter(allComments);

            return allComments.Cast<PostedComment>().OrderBy(comment => comment.Date);
        }

        public static ContentFolder AddNewCommentFolder(IContentRepository contentRepository, IContent contentItemToComment)
        {
            //Why not use the local _contentRepository method? The method can't be static then though....
            var rootFolderReference = contentRepository.Get<StartPage>(ContentReference.StartPage).CommentRoot;

            if (ContentReference.IsNullOrEmpty(rootFolderReference))
                return null;

            var newCommentFolder = contentRepository.GetDefault<ContentFolder>(rootFolderReference);

            newCommentFolder.Name = contentItemToComment.Name;
            contentRepository.Save(newCommentFolder, EPiServer.DataAccess.SaveAction.Publish, EPiServer.Security.AccessLevel.Publish);

            return newCommentFolder;
        }

        public bool CurrentUserHasCommentPublishAccess(ContentReference commentFolderReference)
        {
            if (ContentReference.IsNullOrEmpty(commentFolderReference))
                return false;

            IContent commentFolder = _contentRepository.Get<ContentFolder>(commentFolderReference);
            if (commentFolder == null)
                return false;

            return commentFolder.QueryDistinctAccess(EPiServer.Security.AccessLevel.Publish);
        }

        public bool CommentFolderIsSet(ContentReference commentFolderReference)
        {
            return !ContentReference.IsNullOrEmpty(commentFolderReference);
        }

        public void ReportComment(ContentReference commentReference)
        {
            if (ContentReference.IsNullOrEmpty(commentReference))
                throw new NullReferenceException();

            PostedComment reportedComment = _contentRepository.Get<PostedComment>(commentReference);
            var commentToUpdate = reportedComment.CreateWritableClone() as IVersionable;

            commentToUpdate.StopPublish = DateTime.Now;

            _contentRepository.Save(
                commentToUpdate as IContent,
                EPiServer.DataAccess.SaveAction.Publish,
                EPiServer.Security.AccessLevel.Read);
        }
    }
}