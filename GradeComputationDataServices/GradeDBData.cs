using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace GradeComputationDataServices
{
    public class GradeSQLData : IGradeMngDataService
    {
        private static string connString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=StudentGradesDB;Integrated Security=True;TrustServerCertificate=True;";

        public void AddLog(DModels grade)
        {
            SqlConnection sqlConnection = new SqlConnection(connString);

            string insertStatement = "INSERT INTO GradesPup (SubjectName, Sw1, Sw2, Qz1, Qz2, Assign, Lab, Exam, MidtermGrade, FinalsGrade) " +
                                     "VALUES (@SubjectName, @Sw1, @Sw2, @Qz1, @Qz2, @Assign, @Lab, @Exam, @MidtermGrade, @FinalsGrade)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@SubjectName", grade.SubjectName);
            insertCommand.Parameters.AddWithValue("@Sw1", grade.Sw1.ToString());
            insertCommand.Parameters.AddWithValue("@Sw2", grade.Sw2.ToString());
            insertCommand.Parameters.AddWithValue("@Qz1", grade.Qz1.ToString());
            insertCommand.Parameters.AddWithValue("@Qz2", grade.Qz2.ToString());
            insertCommand.Parameters.AddWithValue("@Assign", grade.Assign.ToString());
            insertCommand.Parameters.AddWithValue("@Lab", grade.Lab.ToString());
            insertCommand.Parameters.AddWithValue("@Exam", grade.Exam.ToString());
            insertCommand.Parameters.AddWithValue("@MidtermGrade", grade.MidtermGrade.ToString());
            insertCommand.Parameters.AddWithValue("@FinalsGrade", grade.FinalsGrade.ToString());

            sqlConnection.Open();
            insertCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public List<DModels> GetGradeLogs()
        {
            return new List<DModels>(); 
        }
        public void DeleteAll()
        {
          
        }
    }
}