using AlloyTraining.Models.Blocks;
using AlloyTraining.Models.ViewModels;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;
using System.Web.Mvc;

namespace AlloyTraining.Controllers
{
    public class ShareThisBlockController : BlockController<ShareThisBlock>
    {
        IPageRouteHelper pageRouteHelper;
        UrlResolver urlResolver;

        public ShareThisBlockController(IPageRouteHelper pageRouteHelper, UrlResolver urlResolver)
        {
            this.pageRouteHelper = pageRouteHelper;
            this.urlResolver = urlResolver;
        }

        public override ActionResult Index(ShareThisBlock currentBlock)
        {
            ShareThisBlockViewModel model = new ShareThisBlockViewModel();
            PageData myPageData = pageRouteHelper.Page;

            var internalUrl = urlResolver.GetUrl(myPageData.PageLink);
            var url = new UrlBuilder(internalUrl);
            Global.UrlRewriteProvider.ConvertToExternal(url, null, System.Text.Encoding.UTF8);
            var friendlyUrl = UriSupport.AbsoluteUrlBySettings(url.ToString());

            model.FriendlyUrl = friendlyUrl;

            return PartialView(model);
        }
    }
}
