using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubXmlReaderFormApp
{
    public interface IRemoteDocumentReader<T>
    {

        List<T> GetAllData(string documentURL);
    }
}
