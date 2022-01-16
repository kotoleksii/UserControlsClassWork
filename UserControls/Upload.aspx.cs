using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserControls
{
    public partial class Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SmartUploader_FileUploaded(object sender, FileUploadedArgs e)
        {
            uploadDetails.Text = $"File was save as '{e.FileName}' to '{e.Path}'";
        }
    }
}