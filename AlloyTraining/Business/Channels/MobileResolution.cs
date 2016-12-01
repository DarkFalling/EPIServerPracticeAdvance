using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlloyTraining.Business.Channels
{
    public class MobileResolution : EPiServer.Web.IDisplayResolution
    {
        public int Height
        {
            get { return 480; }
        }

        public string Id
        {
            get { return this.GetType().FullName; }
        }

        public string Name
        {
            get { return "Mobile (320x480)"; }
        }

        public int Width
        {
            get { return 320; }
        }
    }
}