using ImageRezierFunction.Interface;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


[assembly: FunctionsStartup(typeof(ImageRezierFunction.Startup))]
namespace ImageRezierFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
          builder.Services.AddSingleton<IImageResizer, ImageResizer>();
        }
    }
}
