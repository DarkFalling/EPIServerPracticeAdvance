using System;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiServer.Core;
using EPiServer;

namespace AlloyTraining.Business.Comments
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class CommentInitialization : IInitializableModule
    {
        private bool _eventsAttached = false;

        public void Initialize(InitializationEngine context)
        {
            //Initialization logic, this method is called once after CMS has been initialized
            if (!_eventsAttached)
            {
                ServiceLocator.Current.GetInstance<IContentEvents>().PublishingContent += new EventHandler<ContentEventArgs>(PublishingCommentableContent);
                _eventsAttached = true;
            }
        }

        public void Preload(string[] parameters) { }

        public void Uninitialize(InitializationEngine context)
        {
            //Uninitialization logic
            ServiceLocator.Current.GetInstance<IContentEvents>().PublishingContent -= new EventHandler<EPiServer.ContentEventArgs>(PublishingCommentableContent);
        }

        public static void PublishingCommentableContent(object sender, ContentEventArgs e)
        {
            var content = e.Content as ICommentableContent;
            if (content == null)
                return;

            content.ConfigureCommentSettings();
        }

    }
}