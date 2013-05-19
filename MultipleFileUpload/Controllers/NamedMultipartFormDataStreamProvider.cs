using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace MultipleFileUpload.Controllers
{
    public class NamedMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public NamedMultipartFormDataStreamProvider(string fileName):base(fileName)
        {
        }

        public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
        {
            string fileName = base.GetLocalFileName(headers);
            if (!string.IsNullOrEmpty(headers.ContentDisposition.FileName))
            {
                fileName = headers.ContentDisposition.FileName;
            }
            if (fileName.StartsWith("\"") && fileName.EndsWith("\""))
            {
                fileName = fileName.Trim('"');
            }
            if (fileName.Contains(@"/") || fileName.Contains(@"\"))
            {
                fileName = Path.GetFileName(fileName);
            }
            return fileName;
        }
    }
}