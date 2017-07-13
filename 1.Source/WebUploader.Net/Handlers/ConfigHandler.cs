using System.Web;
using System.Web.Mvc;
using WebUploader.Net.Configs;

namespace WebUploader.Net.Handlers
{
    internal class ConfigHandler : BaseHandler
    {
        public ConfigHandler(HttpContext context) : base(context) { }

        public override ContentResult Process()
        {
            return WriteJson(Config.Items);
        }
    }
}