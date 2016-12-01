using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace AlloyTraining.Models.Blocks
{
    [ContentType(DisplayName = "ListingBlock", GUID = "c08a758e-40b3-4959-bc94-8abb44f643b9", Description = "")]
    public class ListingBlock : BlockData
    {
        [Display(
            GroupName=SystemTabNames.Content,
            Order=100)]
        public virtual String Heading { get; set; }

        [Display(
            GroupName=SystemTabNames.Content,
            Order=200)]
        public virtual PageReference RootPage { get; set; }
    }
}