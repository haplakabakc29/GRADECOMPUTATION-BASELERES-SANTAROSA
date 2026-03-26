using System.IO;
using System.Text.Json;

namespace GradeComputationDataServices
{
    public class GradeData
    {
        public static double sw1, sw2, qz1, qz2, assign, lab, exam;
        public static double midtermGrade = 0;
        public static double finalsGrade = 0;
        public static string subjectName = "";

        private static string filePath = "grades.json";

        public static void SaveData()
        {
            var dataToSave = new GradeModel
            {
                SubjectName = subjectName,
                Sw1 = sw1, Sw2 = sw2, Qz1 = qz1, Qz2 = qz2,
                Assign = assign, Lab = lab, Exam = exam,
                MidtermGrade = midtermGrade, FinalsGrade = finalsGrade
            };

            string jsonString = JsonSerializer.Serialize(dataToSave, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonString);
        }

        public static void LoadData()
        {
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                var loadedData = JsonSerializer.Deserialize<GradeModel>(jsonString);

                subjectName = loadedData.SubjectName;
                sw1 = loadedData.Sw1; sw2 = loadedData.Sw2;
                qz1 = loadedData.Qz1; qz2 = loadedData.Qz2;
                assign = loadedData.Assign; lab = loadedData.Lab; exam = loadedData.Exam;
                midtermGrade = loadedData.MidtermGrade;
                finalsGrade = loadedData.FinalsGrade;
            }
        }
    }
}