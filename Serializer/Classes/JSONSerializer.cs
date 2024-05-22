using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Serializer.Interfaces;

namespace Serializer.Classes
{
    /// <summary>
    /// Класс сериализатор в CSV
    /// </summary>
    public class JSONSerializer : ISerializer
    {
        /// <summary>
        /// Метод сериализации в JSON
        /// </summary>
        /// <param name="obj">Объект сериализации</param>        
        /// <returns>string</returns>
        public string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// Метод десериализации из CSV
        /// </summary>
        /// <param name="string">текст в формате CSV</param>  
        public T Deserialize<T>(string data) where T : new()
        {
            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}
