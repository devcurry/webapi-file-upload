
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

public class CloudFile
{
    public string FileName { get; set; }
    public string URL { get; set; }
    public long Size { get; set; }
    public long BlockCount { get; set; }
    public MultipartFormDataStreamProvider BlockBlob { get; set; }
    public DateTime StartTime { get; set; }
    public string UploadStatusMessage { get; set; }
    public bool IsUploadCompleted { get; set; }
    public string FileKey { get; set; }
    public int FileIndex { get; set; }
}