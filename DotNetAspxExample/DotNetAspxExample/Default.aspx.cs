using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BVSeoSdkDotNet.Config;
using BVSeoSdkDotNet.Content;
using BVSeoSdkDotNet.Model;
using BVSeoSdkDotNet.BVException;

namespace DotNetAspxExample
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BVConfiguration bvConfig = new BVSdkConfiguration();
            bvConfig.addProperty(BVClientConfig.LOAD_SEO_FILES_LOCALLY, "false");
            bvConfig.addProperty(BVClientConfig.CLOUD_KEY, "bodyglove-8e186f6e16e2d688784728b360df41c5");
            bvConfig.addProperty(BVClientConfig.BV_ROOT_FOLDER, "Main_Site-en_US");
            bvConfig.addProperty(BVClientConfig.EXECUTION_TIMEOUT, "300000");

            BVUIContent uiContent = new BVManagedUIContent(bvConfig);

            BVParameters bvParameters = new BVParameters();
            bvParameters.UserAgent = "google";
            bvParameters.ContentType = new BVContentType(BVContentType.REVIEWS);
            bvParameters.SubjectType = new BVSubjectType(BVSubjectType.PRODUCT);
            bvParameters.SubjectId = "50524";
            bvParameters.BaseURI = Request.Url.AbsoluteUri;
            bvParameters.PageURI = Request.Url.ToString();

            String theUIContent = uiContent.getContent(bvParameters);
            BVRRContainer.InnerHtml = theUIContent;
        }
    }
}