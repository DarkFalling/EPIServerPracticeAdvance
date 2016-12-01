using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace AlloyTraining.Models.Blocks
{
    [ContentType(DisplayName = "EditorialBlock", GUID = "d08ba204-808c-4b68-b291-1c9e6dd781ab", Description = "")]
    public class EditorialBlock : BlockData
    {
        
                [CultureSpecific]
                [Display(
                    Name = "Main Body",
                    Description = "Editorial Body",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
                public virtual XhtmlString MainBody { get; set; }
         
    }
}