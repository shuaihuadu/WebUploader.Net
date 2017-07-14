using System;
using WebUploader.Net.Handlers;
using WebUploader.Net.Models;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Response.AddHeader("Content-Type", "text/plain");
            Response.Write(WebUploaderHandler.Process(System.Web.HttpContext.Current, UploadType.Image));
        }
    }
}