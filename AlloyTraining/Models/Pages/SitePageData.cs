using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlloyTraining.Models.Pages
{
    public abstract class SitePageData : EPiServer.Core.PageData
    {
        [Display(GroupName = "SEO", Order = 100)]
        public virtual String MetaTitle { get; set; }

        [Display(GroupName = "SEO", Order = 200)]
        public virtual String MetaKeywords { get; set; }

        [Display(GroupName = "SEO", Order = 300)]
        [UIHint(UIHint.Textarea)]
        public virtual String MetaDescription { get; set; }

        [Display(GroupName = SystemTabNames.Content, Order = 100)]
        [UIHint(UIHint.Image)] //Displays an image instead of a ContentReference
        public virtual ContentReference PageImage { get; set; }

        [Display(GroupName = SystemTabNames.Content, Order = 200)]
        [UIHint(UIHint.Textarea)]
        public virtual String TeaserText { get; set; }

    }
}