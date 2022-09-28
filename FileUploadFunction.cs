using System;
using System.IO;
using System.Threading.Tasks;
using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Drawing.Imaging;
using Azure.Storage.Blobs;

namespace AzureKursusfunction
{
    public static class FileUploadFunction
    {
        [FunctionName("FileUpload")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            var containerName = Environment.GetEnvironmentVariable("ContainerName");
            var conn = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
            try
            {
                //Get File from request and display name and size
                var formdata = await req.ReadFormAsync();
                var file = req.Form.Files["file"];

                //Now we have the file as a pointer to a datastream
                //Create an image from the file variable
                
                // --- Hint you could use the System.Drawing.Image
                // --- And convert the file variable to a stream

                // --- For resizing on could use new Bitmap(image, size)
                // --- Other example could be the ImageSharp package from nuget.org                                

                // --- Save the resized image to a variable of type: MemoryStream (var imageStream = new MemoryStream())
                // --- OBS. set stream position to 0 before uploading image

                // We need to save the image to azure,
                // and we've chosen to save it in a blobstorage

                // --- First create a BlobServiceClient (from the Azure.Storage.Blobs library)

                // When the blob is created we need to uploade the image to it

                // --- Use the BlobContainerClient (From same library as before) to first
                // --- get the blob client using .GetBlobClient
                // --- afterwards Upload the file to the blob

                return new OkObjectResult("");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }
    }
}
