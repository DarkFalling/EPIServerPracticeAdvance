using AlloyTraining.Business;
using AlloyTraining.Models.Pages;
using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlloyTraining.Models.ViewModels
{
    public class DefaultPageViewModel<T> : IPageViewModel<T> where T : SitePageData
    {
        public DefaultPageViewModel(T currentPage)
        {
            CurrentPage = currentPage;
            Section = ContentExtensions.GetSection(currentPage.ContentLink);
            IsSearchPageSet = true;
        }
        public bool IsSearchPageSet { get; set; }
        public string SearchNotActiveMessage { get; set; }
        public T CurrentPage { get; set; }
        public IContent Section { get; set; }
    }
}