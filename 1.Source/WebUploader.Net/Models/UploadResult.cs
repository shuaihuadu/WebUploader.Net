namespace WebUploader.Net.Models
{
    public class UploadResult
    {
        public UploadState State { get; set; }
        public string Url { get; set; }
        public string OriginalFileName { get; set; }
        public string ErrorMessage { get; set; }
        public string StateMessage { get; set; }
    }
}