using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace GradeComputationDataServices
{
    public class GradeJSONData
    {
        private static string filePath = "grades.json";

        public static void SaveToFile(List<GradeModel> allGrades)
        {
            string jsonString = JsonSerializer.Serialize(allGrades, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonString);
        }

        public static List<GradeModel> LoadFromFile()
        {
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<GradeModel>>(jsonString) ?? new List<GradeModel>();
            }
            return new List<GradeModel>();
        }

        public static void ClearHistory()
        {
            if (File.Exists(filePath)) File.Delete(filePath);
        }
    }
}