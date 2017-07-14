using System.Web;
using WebUploader.Net.Models;
using WebUploader.Net.Utilities;

namespace WebUploader.Net.Handlers
{
    public static class WebUploaderHandler
    {
        public static string Process(HttpContext context, UploadType type = UploadType.Default)
        {
            BaseHandler action = null;
            switch (type)
            {
                case UploadType.Default:
                    action = new UploadHandler(context, ConfigHelper.DefaultUploaderConfig);
                    break;
                case UploadType.Image:
                    action = new UploadHandler(context, ConfigHelper.ImageUploaderConfig);
                    break;
                case UploadType.Video:
                    action = new UploadHandler(context, ConfigHelper.VideoUploaderConfig);
                    break;
                default:
                    action = new UploadHandler(context, ConfigHelper.DefaultUploaderConfig);
                    break;
            }
            return action.Process();
        }
    }
}