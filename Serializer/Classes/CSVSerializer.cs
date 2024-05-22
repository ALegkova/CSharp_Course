using Newtonsoft.Json.Linq;
using Serializer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Serializer.Classes
{
    /// <summary>
    /// Класс сериализатор в CSV
    /// </summary>
    public class CSVSerializer : ISerializer
    {
        /// <summary>
        /// Разделитель столбцо.
        /// </summary>        
        private readonly string ColumnSeparator;
        /// <summary>
        /// Разделитель строк
        /// </summary>
        private readonly string RowSeparator;
        private static BindingFlags Flags => BindingFlags.Instance | BindingFlags.Public;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="columnseparator">Разделитель столбцов</param>
        /// <param name="rowseparator">Разделитель строк</param>
        /// <returns>CSVSerializer</returns>
        public CSVSerializer(string columnseparator, string rowseparator)
        {
            this.ColumnSeparator = columnseparator;
            this.RowSeparator = rowseparator;            
        }

        /// <summary>
        /// Метод сериализации в CSV
        /// </summary>
        /// <param name="obj">Объект сериализации</param>        
        /// <returns>string</returns>
        public string Serialize<T>(T obj)
        {
            if (string.IsNullOrEmpty(ColumnSeparator))
               //throw new ArgumentNullException(nameof(ColumnSeparator));
               throw new ArgumentNullException($"Разделитель столбцов не может быть пустой строкой или null");
            if (string.IsNullOrEmpty(RowSeparator))
                throw new ArgumentNullException($"Разделитель строк не может быть пустой строкой или null");

            StringBuilder result = new StringBuilder();

            Action<string, string> checkForInvalidChatacrers = (name, value) =>
            {
                if (value == null) return;
                if (value.Contains(ColumnSeparator))
                {
                    throw new ArgumentException($"{name} '{value}' содержит недопустимый символ '{ColumnSeparator}'");
                }
                if (value.Contains(RowSeparator))
                {
                    throw new ArgumentException($"{name} '{value}' содержит недопустимый символ '{RowSeparator}'");
                }
            };

            StringBuilder header = new StringBuilder();
            StringBuilder data = new StringBuilder();

            var fields = obj.GetType().GetProperties(Flags);
            foreach ( var field in fields )
            {
                var name = field.Name;
                var value = field.GetValue(obj);

                checkForInvalidChatacrers("Название поля", name as string);
                checkForInvalidChatacrers("Значение поля", value as string);

                //Заголовок
                if (header.Length > 0)
                {
                    header.Append(ColumnSeparator);
                }
                header.Append(name);

                //Данные
                if (data.Length > 0)
                { 
                    data.Append(ColumnSeparator); 
                }
                if ( value == null )
                    data.Append("");
                else 
                    data.Append(value);
            }

            result.Append(header);
            if (result.Length > 0) 
            {
                result.Append(RowSeparator);
            }
            result.Append(data);
            
            return result.ToString();
        }

        /// <summary>
        /// Метод десериализации из CSV
        /// </summary>
        /// <param name="string">текст в формате CSV</param>     
        /// <returns>Объект класса T</returns>
        public T Deserialize<T>(string data) where T : new()
        {
            T obj = new T();
            
            var objdata = data.Split(RowSeparator, StringSplitOptions.TrimEntries);
            var names = objdata[0].Split(ColumnSeparator, StringSplitOptions.TrimEntries); 
            var values = objdata[1].Split(ColumnSeparator, StringSplitOptions.TrimEntries);
           
            if (names.Length != values.Length)
                throw new FormatException("Количество переданных нпзваний свойств не совпадает с количеством значений!");

            for (int i = 0; i < names.Length; i++)
            {                
                var field = obj.GetType().GetProperty(names[i], Flags);

                if (field != null)
                {
                    var value = values[i];
                    var column = names[i];
                    var converter = TypeDescriptor.GetConverter(field.PropertyType);
                    var convertedvalue = converter.ConvertFrom(value);
                    field.SetValue(obj, convertedvalue);
                    
                }

             }
             return obj;

        }
     }
}
