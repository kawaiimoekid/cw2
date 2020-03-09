using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace APBD2
{
    class Program
    {
        static void Main(string[] args)
        {
            var parameters = new Parameters(args);

            var lines = File.ReadAllLines(parameters.Source).Select(x => x.Split(",")).ToList();
            LogInvalid(lines);

            var students = lines.Where(x => x.Length == 9 && x.All(y => !string.IsNullOrWhiteSpace(y)))
                .Select(x => Student.FromCsv(x))
                .GroupBy(x => x.IndexNumber)
                .Select(x => x.First())
                .ToList();
            var university = new University(students);

            if (parameters.Format == "json")
            {
                SaveAsJson(university, parameters.Destination);
            }
            else
            {
                SaveAsXml(university, parameters.Destination);
            }
        }

        private static void LogInvalid(ICollection<string[]> lines)
        {
            var invalidLength = lines.Where(x => x.Length != 9);
            var invalidData = lines.Where(x => x.Any(y => string.IsNullOrWhiteSpace(y)));
            var builder = new StringBuilder();

            builder.AppendLine("Invalid length:");
            foreach (var invalid in invalidLength)
            {
                builder.AppendLine($"({invalid.Length}) {string.Join(",", invalid)}");
            }

            builder.AppendLine("\nInvalid data:");
            foreach (var invalid in invalidData)
            {
                builder.AppendLine($"{string.Join(",", invalid)}");
            }

            File.WriteAllText("log.txt", builder.ToString());
        }

        private static void SaveAsJson(University university, string path)
        {
            var json = JsonConvert.SerializeObject(university, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        private static void SaveAsXml(University university, string path)
        {
            var writer = new FileStream(path, FileMode.Create);
            var serializer = new XmlSerializer(typeof(University));
            serializer.Serialize(writer, university);
        }
    }
}
