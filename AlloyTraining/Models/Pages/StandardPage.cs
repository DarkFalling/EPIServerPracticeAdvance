using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using AlloyTraining.Models.Blocks;

namespace AlloyTraining.Models.Pages
{
    [ContentType(DisplayName = "StandardPage", GUID = "b3435462-777f-4c0f-b640-63dab80a807f", Description = "Standard Page Type")]
    public class StandardPage : SitePageData
    {

        [CultureSpecific]
        [Display(
            Name = "Main body",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 310)]
        public virtual XhtmlString MainBody { get; set; }

        [Display(Order=320, GroupName=SystemTabNames.Content)]
        public virtual TeaserBlock Teaser { get; set; }


    }
}