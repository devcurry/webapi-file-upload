using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MultipleFileUpload.Controllers
{
    public class UploadController : ApiController
    {
        //[HttpPost]
        //public async Task<object> UploadFile()
        //{
        //    if (!Request.Content.IsMimeMultipartContent("form-data"))
        //    {
        //        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.UnsupportedMediaType));
        //    }

        //    MultipartFormDataStreamProvider streamProvider = new MultipartFormDataStreamProvider(
        //        HttpContext.Current.Server.MapPath("~/App_Data/Temp/"));

        //    await Request.Content.ReadAsMultipartAsync(streamProvider);

        //    foreach (MultipartFileData fileData in streamProvider.FileData)
        //    {
        //        string fileName = "";
        //        if (string.IsNullOrEmpty(fileData.Headers.ContentDisposition.FileName))
        //        {
        //            fileName = Guid.NewGuid().ToString();
        //        }
        //        fileName = fileData.Headers.ContentDisposition.FileName;
        //        if (fileName.StartsWith("\"") && fileName.EndsWith("\""))
        //        {
        //            fileName = fileName.Trim('"');
        //        }
        //        if (fileName.Contains(@"/") || fileName.Contains(@"\"))
        //        {
        //            fileName = Path.GetFileName(fileName);
        //        }
        //        File.Move(fileData.LocalFileName, Path.Combine(HttpContext.Current.Server.MapPath("~/App_Data/"), fileName));
        //    }

        //    // Create response
        //    return new 
        //    {
        //         FileNames = streamProvider.FileData.Select(entry => entry.LocalFileName),
        //    };
        //}

        // Using NamedMultipartFormDataStreamProvider
        [HttpPost]
        public async Task<object> UploadFile()
        {
            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.UnsupportedMediaType));
            }

            NamedMultipartFormDataStreamProvider streamProvider = new NamedMultipartFormDataStreamProvider(
                HttpContext.Current.Server.MapPath("~/App_Data/"));

            await Request.Content.ReadAsMultipartAsync(streamProvider);
            
            return new
            {
                FileNames = streamProvider.FileData.Select(entry => entry.LocalFileName),
            };
        }
    }
}
