using System;
using System.Collections.Generic;

namespace GradeComputationDataServices
{
    public class GradeData
    {
        public static List<GradeModel> allGrades = new List<GradeModel>();

        public static double sw1, sw2, qz1, qz2, assign, lab, exam;
        public static double midtermGrade = 0, finalsGrade = 0;
        public static string subjectName = "";

        public static void ResetData()
        {
            sw1 = 0; sw2 = 0; qz1 = 0; qz2 = 0;
            assign = 0; lab = 0; exam = 0;
            midtermGrade = 0;
            finalsGrade = 0;
            subjectName = "";
        }

        public static void SaveData()
        {
            GradeSQLData.SaveToDatabase();

            GradeModel newEntry = new GradeModel
            {
                SubjectName = subjectName,
                Sw1 = sw1,
                Sw2 = sw2,
                Qz1 = qz1,
                Qz2 = qz2,
                Assign = assign,
                Lab = lab,
                Exam = exam,
                MidtermGrade = midtermGrade,
                FinalsGrade = finalsGrade
            };

            allGrades.Add(newEntry);

            GradeJSONData.SaveToFile(allGrades);

            Console.WriteLine("\n[SUCCESS] Data for " + subjectName + " added to history.");
        }

        public static void LoadData()
        {
            allGrades = GradeJSONData.LoadFromFile();
        }
    }
}