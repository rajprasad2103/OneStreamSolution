using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneStreamEncryption
{
    public class AppSettings
    {
        public string? SecretKey { get; set; }
        public string? VectorKey { get; set; }
    }

}
