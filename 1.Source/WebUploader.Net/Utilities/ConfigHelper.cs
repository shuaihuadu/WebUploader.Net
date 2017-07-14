using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using WebUploader.Net.Models;

namespace WebUploader.Net.Utilities
{
    internal static class ConfigHelper
    {
        const string WEB_UPLOADER_CONFIG_FILE_PATH = "WebUploaderConfigFilePath";
        //const string WebUploaderConfigFilePath = "webuploader.config.json"; //only for unit tests
        static readonly string WebUploaderConfigFilePath = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings[WEB_UPLOADER_CONFIG_FILE_PATH]);
        static WebUploaderConfig GetConfigs()
        {
            if (!ConfigurationManager.AppSettings.AllKeys.ToList().Contains(WEB_UPLOADER_CONFIG_FILE_PATH))
            {
                throw new ConfigurationErrorsException(string.Format("\"{0}\" not found in AppSettings from Config file.", WEB_UPLOADER_CONFIG_FILE_PATH));
            }
            var json = File.ReadAllText(WebUploaderConfigFilePath);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<WebUploaderConfig>(json);
        }

        public static UploaderConfig ImageUploaderConfig
        {
            get
            {
                return GetConfigs().Image;
            }
        }

        public static UploaderConfig VideoUploaderConfig
        {
            get
            {
                return GetConfigs().Video;
            }
        }

        public static UploaderConfig DefaultUploaderConfig
        {
            get
            {
                return GetConfigs().Default;
            }
        }
    }
}