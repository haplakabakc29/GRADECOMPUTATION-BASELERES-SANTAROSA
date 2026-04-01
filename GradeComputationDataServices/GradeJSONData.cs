using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace GradeComputationDataServices
{
    public class GradeJSONData : IGradeMngDataService
    {
        private static string _jsonFileName = "grades.json";

        public void AddLog(DModels account)
        {
            List<DModels> allGrades = LoadFromFile();
            allGrades.Add(account);
            SaveToFile(allGrades);
        }

        public List<DModels> GetGradeLogs()
        {
            return LoadFromFile();
        }

        public void DeleteAll()
        {
            ClearHistory();
        }

        public static void SaveToFile(List<DModels> allGrades)
        {
            using (var outputStream = File.Create(_jsonFileName))
            {
                JsonSerializer.Serialize<List<DModels>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions { Indented = true }),
                    allGrades);
            }
        }

        public static List<DModels> LoadFromFile()
        {
            List<DModels> accounts = new List<DModels>();
            if (!File.Exists(_jsonFileName)) return accounts;

            using (var jsonFileReader = File.OpenText(_jsonFileName))
            {
                accounts = JsonSerializer.Deserialize<List<DModels>>(
                    jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                    .ToList();
            }
            return accounts;
        }

        public static void ClearHistory()
        {
            if (File.Exists(_jsonFileName)) File.Delete(_jsonFileName);
        }
    }
}