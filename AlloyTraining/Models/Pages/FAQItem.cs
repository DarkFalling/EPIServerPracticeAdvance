using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace AlloyTraining.Models.Pages
{
    [ContentType(DisplayName = "FAQItem", GUID = "4ff7df0e-5daa-4b12-9a4a-4f2af7871bb8", Description = "", AvailableInEditMode=false)]
    public class FAQItem : SitePageData
    {
        [Display(
            GroupName=SystemTabNames.Content,
            Order= 10)]
        public virtual String Question { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual XhtmlString Answer { get; set; }
    }
}