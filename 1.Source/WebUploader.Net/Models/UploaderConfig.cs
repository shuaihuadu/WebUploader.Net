namespace WebUploader.Net.Models
{
    internal class WebUploaderConfig
    {
        public UploaderConfig Image { get; set; }
        public UploaderConfig Video { get; set; }
        public UploaderConfig Default { get; set; }
    }

    internal class UploaderConfig
    {
        /// <summary>
        /// 文件命名规则
        /// </summary>
        public string PathFormat { get; set; }
        /// <summary>
        /// 上传表单域名称
        /// </summary>
        public string UploadFieldName { get; set; }
        /// <summary>
        /// 上传大小限制
        /// </summary>
        public int SizeLimit { get; set; }
        /// <summary>
        /// 上传允许的文件格式
        /// </summary>
        public string[] AllowExtensions { get; set; }
    }
}