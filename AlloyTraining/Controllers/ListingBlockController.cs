using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using AlloyTraining.Models.Blocks;
using EPiServer.ServiceLocation;
using AlloyTraining.Models.ViewModels;

namespace AlloyTraining.Controllers
{
    public class ListingBlockController : BlockController<ListingBlock>
    {
        public override ActionResult Index(ListingBlock currentBlock)
        {
            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            var model = new ListingBlockModel();
            model.Heading = currentBlock.Heading;
            if (currentBlock.RootPage != null)
            {
                model.Items = contentRepository.GetChildren<PageData>(currentBlock.RootPage);
            }
            else
            {
                model.Items = null;
            }

            return PartialView(model);
        }
    }
}
