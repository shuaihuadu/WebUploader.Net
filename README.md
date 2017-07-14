# WebUploader.Net

## 1.About

The WebUploader.NET is a server configuration library of [webuploader](https://github.com/fex-team/webuploader).

For more information,Please refer to [webuploader](https://github.com/fex-team/webuploader)
## 2.Usage

1. Add ```<add key="WebUploaderConfigFilePath" value="~/config/webuploader.config.json"/>``` to `AppSettings` in Web.Config.
2. Edit webuploader.config.json , the configurations as below:
- PathFormat
- UploadFieldName
- SizeLimit
- AllowExtensions

3. You need to set your upload server url when you create a webuploader in your javascript file, and using `WebUploaderHandler` processing the upload requests.

    Please refer to [webuploader.config.json](https://github.com/dushuaihua/WebUploader.Net/blob/dev/1.Source/WebUploader.Net/webuploader.config.json) 

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ASP.NET MVC:
```
public JsonResult Upload(UploadType type = UploadType.Image)
{
    return Json(WebUploaderHandler.Process(System.Web.HttpContext.Current, type));
}
```

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ASP.NET WebForm:

```
Response.AddHeader("Content-Type", "text/plain");
Response.Write(WebUploaderHandler.Process(System.Web.HttpContext.Current, UploadType.Image));
```