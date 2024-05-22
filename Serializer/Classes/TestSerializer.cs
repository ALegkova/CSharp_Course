using Serializer.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializer.Classes
{
    /// <summary>
    /// Класс тестирования сериализации
    /// </summary>
    public class TestSerializer
    {
        /// <summary>
        /// Количество итераций
        /// </summary>
        private readonly int iterations;
        /// <summary>
        /// Класс сериализатор
        /// </summary>
        private readonly ISerializer serializer;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="iterations">Количество итераций/param>
        /// <param name="serializer">Класс сериализатора</param>
        public TestSerializer(int iterations, ISerializer serializer)
        {
            this.iterations = iterations;
            this.serializer = serializer;
        }
        /// <summary>
        /// Тест сериализации
        /// </summary>
        /// <param name="obj">Объект для сериализации/param>
        /// <returns>string</returns>
        public string TestRunSerializing<T>(T obj) where T : new()
        {
            string outinfo = $"Количество итераций: {iterations}\r\n";
            Stopwatch stopwatch = new Stopwatch();
            try
            {
                stopwatch.Start();
                string strProperties = string.Empty;
                for (int i = 0; i < iterations; i++)
                {
                    strProperties = serializer.Serialize(obj);
                }
                stopwatch.Stop();
                outinfo += $"Сериализатор: {serializer.GetType().Name}{Environment.NewLine} Результат сериализации класса: {strProperties}\r\n";
                outinfo += $"{serializer.GetType().Name}.{serializer.GetType().GetMethods().FirstOrDefault().Name}:\t{stopwatch.Elapsed.Seconds}сек.{stopwatch.Elapsed.Milliseconds}мсек.\r\n";
                stopwatch.Start();
                for (int i = 0; i < iterations; i++)
                {
                    T objF = serializer.Deserialize<T>(strProperties);
                }
                stopwatch.Stop();
                outinfo += $"{serializer.GetType().Name}.{serializer.GetType().GetMethods().ElementAt(1).Name}:\t{stopwatch.Elapsed.Seconds}сек.{stopwatch.Elapsed.Milliseconds}мсек.{Environment.NewLine}";
            }
            catch (Exception e)
            {
                   throw new FormatException($"Неверный формат данных! \r\n{e.Message}");
            }
            return outinfo;
        }
    }
}
