using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetFormApp
{
    public class Factory
    {
        public static IPerson getRegmem()
        {
            return new RegMem();
        }

        public static IRemoteDocumentReader<IPerson> GetRemoteDocumentReader()
        {
            return new MyRemoteXmlReaderClass();
        }

    }
}
