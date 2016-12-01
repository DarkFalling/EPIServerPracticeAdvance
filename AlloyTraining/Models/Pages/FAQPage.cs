using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using System.Collections.Generic;

namespace AlloyTraining.Models.Pages
{
    [ContentType(DisplayName = "FAQPage", GUID = "d7f530d6-bd42-4d77-8e18-e780142dcf91", Description = "")]
    public class FAQPage : SitePageData
    {
        [Ignore] // ignored as a property for this page type (will not result in a property for this page type)
        public IList<FAQItem> FAQItems { get; set; }
    }
}