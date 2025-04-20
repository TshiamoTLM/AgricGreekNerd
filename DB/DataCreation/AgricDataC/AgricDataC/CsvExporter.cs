using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AgricDataC
{
    public static class CsvExporter
    {
        public static void ExportToCsv<T>(List<T> data, string filePath)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath)!); // Ensure folder exists

            using StreamWriter writer = new StreamWriter(filePath);
            var properties = typeof(T).GetProperties();

            // Header
            writer.WriteLine(string.Join(",", properties.Select(p => p.Name)));

            // Rows
            foreach (var item in data)
            {
                var values = properties.Select(p =>
                {
                    var value = p.GetValue(item);
                    return value != null ? value.ToString()!.Replace(",", ";") : "";
                });

                writer.WriteLine(string.Join(",", values));
            }

            Console.WriteLine($"✅ Exported {data.Count} records to: {filePath}");
        }
    }
}
