using Newtonsoft.Json;
using System.Web;
using System.Web.Mvc;

namespace WebUploader.Net.Handlers
{
    internal abstract class BaseHandler
    {
        public BaseHandler(HttpContext context)
        {
            Request = context.Request;
            Context = context;
            Server = context.Server;
        }

        public abstract ContentResult Process();

        protected ContentResult WriteJson(object response)
        {
            string jsonpCallback = Request["callback"], json = JsonConvert.SerializeObject(response);
            if (string.IsNullOrWhiteSpace(jsonpCallback))
            {
                return new ContentResult { Content = json };
            }
            else
            {
                return new ContentResult { ContentType = "application/javascript", Content = string.Format("{0}({1});", jsonpCallback, json) };
            }
        }

        public HttpRequest Request { get; private set; }
        public HttpContext Context { get; private set; }
        public HttpServerUtility Server { get; private set; }
    }
}
