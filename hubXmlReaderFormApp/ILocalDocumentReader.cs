using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubXmlReaderFormApp

{
    public interface ILocalDocumentReader<T>
    {
        List<T> GetAllData(string pathToDocument);
    }
}
