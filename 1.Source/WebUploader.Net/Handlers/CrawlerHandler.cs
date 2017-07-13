using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUploader.Net.Models;

namespace WebUploader.Net.Handlers
{
    internal class CrawlerHandler : BaseHandler
    {
        private string[] Sources;
        private Crawler[] Crawlers;
        public CrawlerHandler(HttpContext context) : base(context) { }

        public override ContentResult Process()
        {
            Sources = Request.Form.GetValues("source[]");
            if (Sources == null || Sources.Length == 0)
            {
                return WriteJson(new
                {
                    state = "参数错误：没有指定抓取源"
                });
            }
            Crawlers = Sources.Select(x => new Crawler(x, Server).Fetch()).ToArray();
            return WriteJson(new
            {
                state = "SUCCESS",
                list = Crawlers.Select(x => new
                {
                    state = x.State,
                    source = x.SourceUrl,
                    url = x.ServerUrl
                })
            });
        }
    }
}