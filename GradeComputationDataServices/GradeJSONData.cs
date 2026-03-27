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
            try
            {
                string jsonString = JsonSerializer.Serialize(allGrades, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n[FILE ERROR] Could not save: " + ex.Message);
            }
        }

        public static List<GradeModel> LoadFromFile()
        {
            if (File.Exists(filePath))
            {
                try
                {
                    string jsonString = File.ReadAllText(filePath);
                    return JsonSerializer.Deserialize<List<GradeModel>>(jsonString) ?? new List<GradeModel>();
                }
                catch
                {
                    return new List<GradeModel>();
                }
            }
            return new List<GradeModel>();
        }
    }
}