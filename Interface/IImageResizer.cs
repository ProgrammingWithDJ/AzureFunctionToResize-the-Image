using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageRezierFunction.Interface
{
    public interface IImageResizer
    {
        void Resize(Stream input,Stream output);
    }
}
