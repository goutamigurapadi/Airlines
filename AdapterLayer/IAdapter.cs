using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterLayer
{
    //Generic interface to add airlines data, to get fligh summary
    public interface IAdapter<T>
    {
        T Add(string[] data);
        string Get(T obj);

    }
}
