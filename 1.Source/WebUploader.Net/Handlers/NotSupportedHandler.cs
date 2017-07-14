using System.Web;

namespace WebUploader.Net.Handlers
{
    internal class NotSupportedHandler : BaseHandler
    {
        public NotSupportedHandler(HttpContext context) : base(context)
        {
        }

        public override string Process()
        {
            return WriteJson(new
            {
                state = "action 参数为空或者 action 不被支持。"
            });
        }
    }
}