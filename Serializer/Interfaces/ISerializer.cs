using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializer.Interfaces
{
    public interface ISerializer
    {
        public string Serialize<T>(T obj);

        public T Deserialize<T>(string data) where T : new();       
    }
}
