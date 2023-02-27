using ImageRezierFunction.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Jpeg;

namespace ImageRezierFunction
{
    public class ImageResizer : IImageResizer
    {
        public void Resize(Stream input, Stream output)
        {
            using(Image image = Image.Load(input))
            {
                image.Mutate(x =>x.Resize(image.Width/2, image.Height/2));
                image.Save(output, new JpegEncoder());
            }
        }
    }
}
