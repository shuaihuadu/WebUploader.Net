using System.Web;
using System.Web.Mvc;

namespace WebUploader.Net.Handlers
{
    internal class NotSupportedHandler : BaseHandler
    {
        public NotSupportedHandler(HttpContext context) : base(context)
        {
        }

        public override ContentResult Process()
        {
            return WriteJson(new
            {
                state = "action 参数为空或者 action 不被支持。"
            });
        }
    }
}