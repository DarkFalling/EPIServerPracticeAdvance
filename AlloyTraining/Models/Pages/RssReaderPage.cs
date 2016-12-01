using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer;

namespace AlloyTraining.Models.Pages
{
    [ContentType(DisplayName = "RssReaderPage", GUID = "b17aa04e-38ce-422a-a46b-a31b78daa9da", Description = "")]
    public class RssReaderPage : StandardPage
    {
        [CultureSpecific]
        [Editable(true)]
        [Display(
                    Name = "RSS Feed URL",
                    Description = "URL for RSS feed",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
        [Required]
        public virtual Url RssUrl { get; set; }

        [Editable(true)]
        [Display(
            Name = "Heading",
            Description = "Heading for the RSS feed",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        [CultureSpecific]
        public virtual String Heading { get; set; }

        [Editable(true)]
        [Display(
            Name = "Descriptive Text",
            Description = "Descriptive text for the RSS feed",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        [CultureSpecific]
        public virtual XhtmlString DescriptiveText { get; set; }

        [Editable(true)]
        [Display(
            Name = "Max Count",
            Description = "Maximum number of items to display",
            GroupName = SystemTabNames.Content,
            Order = 4)]
        public virtual int MaxCount { get; set; }

        /// <summary>
        /// Sets the default property values on the content data.
        /// </summary>
        /// <param name="contentType">Type of the content.</param>
        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);

            MaxCount = 5;
            Heading = this.Name;
        }
    }
}