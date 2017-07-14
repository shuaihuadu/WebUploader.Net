using System;
using System.IO;
using System.Linq;
using System.Web;
using WebUploader.Net.Models;
using WebUploader.Net.Utilities;

namespace WebUploader.Net.Handlers
{
    internal class UploadHandler : BaseHandler
    {
        public UploaderConfig WebUploaderConfig { get; private set; }
        public UploadResult Result { get; private set; }
        public UploadHandler(HttpContext context, UploaderConfig config) : base(context)
        {
            WebUploaderConfig = config;
            Result = new UploadResult { State = UploadState.Unknown };
        }
        public override string Process()
        {
            byte[] uploadFileBytes = null;
            string uploadFileName = null;

            if (WebUploaderConfig.Base64)
            {
                uploadFileName = WebUploaderConfig.Base64Filename;
                uploadFileBytes = Convert.FromBase64String(Request[WebUploaderConfig.UploadFieldName]);
            }
            else
            {
                var file = Request.Files[WebUploaderConfig.UploadFieldName];
                uploadFileName = file.FileName;

                if (!CheckFileType(uploadFileName))
                {
                    Result.State = UploadState.TypeNotAllow;
                    return WriteResult();
                }
                if (!CheckFileSize(file.ContentLength))
                {
                    Result.State = UploadState.SizeLimitExceed;
                    return WriteResult();
                }

                uploadFileBytes = new byte[file.ContentLength];
                try
                {
                    file.InputStream.Read(uploadFileBytes, 0, file.ContentLength);
                }
                catch (Exception)
                {
                    Result.State = UploadState.NetworkError;
                    return WriteResult();
                }
            }

            Result.OriginFileName = uploadFileName;

            var savePath = PathFormatter.Format(uploadFileName, WebUploaderConfig.PathFormat);
            var localPath = Server.MapPath(savePath);
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(localPath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(localPath));
                }
                File.WriteAllBytes(localPath, uploadFileBytes);
                Result.Url = savePath;
                Result.State = UploadState.Success;
            }
            catch (Exception e)
            {
                Result.State = UploadState.FileAccessError;
                Result.ErrorMessage = e.Message;
            }
            return WriteResult();
        }
        private string WriteResult()
        {
            return WriteJson(new
            {
                state = GetStateMessage(Result.State),
                url = Result.Url,
                title = Result.OriginFileName,
                original = Result.OriginFileName,
                error = Result.ErrorMessage
            });
        }
        private string GetStateMessage(UploadState state)
        {
            switch (state)
            {
                case UploadState.Success:
                    return "SUCCESS";
                case UploadState.FileAccessError:
                    return "文件访问出错，请检查写入权限";
                case UploadState.SizeLimitExceed:
                    return "文件大小超出服务器限制";
                case UploadState.TypeNotAllow:
                    return "不允许的文件格式";
                case UploadState.NetworkError:
                    return "网络错误";
            }
            return "未知错误";
        }
        private bool CheckFileType(string filename)
        {
            var fileExtension = Path.GetExtension(filename).ToLower();
            return WebUploaderConfig.AllowExtensions.Select(x => x.ToLower()).Contains(fileExtension);
        }
        private bool CheckFileSize(int size)
        {
            return size < WebUploaderConfig.SizeLimit;
        }
    }
}