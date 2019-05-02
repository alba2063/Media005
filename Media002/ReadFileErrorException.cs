using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media002
{
    class ReadFileErrorException : Exception
    {
        public ReadFileErrorException(string file, Exception ex)
            : base(string.Format("Error reading file {0}\n {1}", file, ex.Message))
        {
        }

        public ReadFileErrorException(string file)
            : base(string.Format("Error reading file {0}\n", file))
        {
        }
    }
}
