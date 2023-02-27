using System;
using System.IO;
using ImageRezierFunction.Interface;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ImageRezierFunction
{
    [StorageAccount("BlobConnectionString")]
    public class Function1
    {
        private readonly IImageResizer imageResizer;

        public Function1(IImageResizer imageResizer) => this.imageResizer = imageResizer;

        [FunctionName("Function1")]
        public void Run([BlobTrigger("normal-size/{name}")]Stream inputBlob,

            [Blob("reduced-size/{name}", FileAccess.Write)] Stream outputBlob,
            
            string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {inputBlob.Length} Bytes");

            try
            {
                this.imageResizer.Resize(inputBlob,outputBlob);

                log.LogInformation("Redeced image is saved to blob storage");
            }
            catch (Exception ex) {

                log.LogError("Resize error", ex);
            }
        }
    }
}
