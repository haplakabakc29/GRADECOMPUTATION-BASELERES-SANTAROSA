using System;
using System.Collections.Generic;

namespace GradeComputationDataServices
{
    public class GradeData
    {
        public static List<DModels> allGrades = new List<DModels>();
        public static double sw1, sw2, qz1, qz2, assign, lab, exam;
        public static double midtermGrade = 0, finalsGrade = 0;
        public static string subjectName = "";

        public static void ResetData()
        {
            sw1 = 0; sw2 = 0; qz1 = 0; qz2 = 0;
            assign = 0; lab = 0; exam = 0;
            midtermGrade = 0; finalsGrade = 0;
            subjectName = "";
        }

        public static void SaveData()
        {
            DModels newEntry = new DModels
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

      
            new GradeSQLData().AddLog(newEntry);
            
            allGrades.Add(newEntry);
            GradeJSONData.SaveToFile(allGrades);
        }

        public static void ViewHistory()
        {
            foreach (var g in allGrades)
            {
                Console.WriteLine("Subject: " + g.SubjectName + " | Grade MIDTERM: " + g.MidtermGrade + " | Grade Finals: " + g.FinalsGrade);
            }
        }

        public static void DeleteHistory()
        {
            allGrades.Clear();             
            GradeJSONData.ClearHistory();
        }

        public static void LoadData()
        {
            allGrades = GradeJSONData.LoadFromFile();
        }
    }
}