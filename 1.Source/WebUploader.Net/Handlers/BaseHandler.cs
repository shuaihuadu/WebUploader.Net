using Newtonsoft.Json;
using System.Web;

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
        public abstract string Process();
        protected string WriteJson(object response)
        {
            string jsonpCallback = Request["callback"], json = JsonConvert.SerializeObject(response);
            if (string.IsNullOrWhiteSpace(jsonpCallback))
            {
                return json;
            }
            else
            {
                return string.Format("{0}({1});", jsonpCallback, json);
            }
        }
        public HttpRequest Request { get; private set; }
        public HttpContext Context { get; private set; }
        public HttpServerUtility Server { get; private set; }
    }
}
