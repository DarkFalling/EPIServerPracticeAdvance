using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace AlloyTraining.Models.Blocks
{
    /// <remarks>
    /// A content type should always have a GUID defined!
    /// The GUID has been commented out in this file for training purposes, so that it is possible to copy a content type 
    /// from the solution files into the AlloyTraining project without getting a conflict, should the content type already exist there.
    /// </remarks>
    [ContentType(DisplayName = "TeaserBlock", Description = "")] //GUID = "3ec2370a-21eb-4000-bd5b-38ce4e35cc2e"
    public class TeaserBlock : BlockData
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 100)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference TeaserImage { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 200)]
        public virtual string TeaserHeading { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 300)]
        [UIHint(UIHint.Textarea)]
        public virtual string TeaserText { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 400)]
        public virtual PageReference TeaserLink { get; set; }
    }
}