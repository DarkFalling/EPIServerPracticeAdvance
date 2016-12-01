using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace AlloyTraining.Models.Blocks
{
    [ContentType(
        AvailableInEditMode = false,
        DisplayName = "PostedComment",
        GUID = "fc231072-780c-4bdd-974d-ec20090f541a",
        Description = "")]
    public class PostedComment : BlockData
    {
        [Display(
                  Name = "Date",
                  Description = "Date when the comment was added",
                  GroupName = SystemTabNames.Content,
                  Order = 100)]
        public virtual DateTime Date { get; set; }

        [Display(
           Name = "Name",
           Description = "Name of the person making the comment",
           GroupName = SystemTabNames.Content,
           Order = 200)]
        public virtual String CommentatorName { get; set; }

        [Display(
           Name = "Text",
           Description = "The actual comment text",
           GroupName = SystemTabNames.Content,
           Order = 300)]
        public virtual String Text { get; set; }
    }
}