using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace AlloyTraining.Models.Media
{
    [ContentType()] //GUID = "23d6d458-6c11-4a5c-a9d7-9580d224ccb7"
    public class ImageFile : ImageData
    {
        public virtual String Description { get; set; }
    }
}