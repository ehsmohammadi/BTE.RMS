using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using BTE.RMS.Interface.Contract.Facade;
using BTE.RMS.Interface.Contract.Model;

namespace BTE.RMS.Interface.WebApi.Host.Controllers
{
    public class MeetingFilesController : ApiController
    {
        private readonly IMeetingFacadeService meetingService;

        public MeetingFilesController(IMeetingFacadeService meetingService)
        {
            this.meetingService = meetingService;
        }

        [HttpPost]
        public async Task<HttpResponseMessage> PostFormData(long meetingId)
        {
            //Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);

            var files = new List<FileDto>();
            try
            {
                // Read the form data.
                await Request.Content.ReadAsMultipartAsync(provider);
                // This illustrates how to get the file names.
                foreach (var file in provider.FileData)
                {
                    files.Add(new FileDto
                    {
                        ContentType = file.Headers.ContentType.MediaType,
                        FileContent = Convert.ToBase64String(File.ReadAllBytes(file.LocalFileName))
                    });

                }
                meetingService.AddFiles(meetingId, Guid.Empty,files);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
