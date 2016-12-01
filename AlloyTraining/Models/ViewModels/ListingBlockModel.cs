using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlloyTraining.Models.ViewModels
{
    public class ListingBlockModel
    {
        public String Heading { get; set; }
        public IEnumerable<PageData> Items { get; set; }
    }
}