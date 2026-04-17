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
            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                string insertStatement = "INSERT INTO GradesPup (SubjectName, Sw1, Sw2, Qz1, Qz2, Assign, Lab, Exam, MidtermGrade, FinalsGrade) " +
                                         "VALUES (@SubjectName, @Sw1, @Sw2, @Qz1, @Qz2, @Assign, @Lab, @Exam, @MidtermGrade, @FinalsGrade)";

                SqlCommand cmd = new SqlCommand(insertStatement, sqlConnection);
                cmd.Parameters.AddWithValue("@SubjectName", grade.SubjectName);
                cmd.Parameters.AddWithValue("@Sw1", grade.Sw1);
                cmd.Parameters.AddWithValue("@Sw2", grade.Sw2);
                cmd.Parameters.AddWithValue("@Qz1", grade.Qz1);
                cmd.Parameters.AddWithValue("@Qz2", grade.Qz2);
                cmd.Parameters.AddWithValue("@Assign", grade.Assign);
                cmd.Parameters.AddWithValue("@Lab", grade.Lab);
                cmd.Parameters.AddWithValue("@Exam", grade.Exam);
                cmd.Parameters.AddWithValue("@MidtermGrade", grade.MidtermGrade);
                cmd.Parameters.AddWithValue("@FinalsGrade", grade.FinalsGrade);

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public void UpdateGrade(DModels grade)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                string query = "UPDATE GradesPup SET MidtermGrade = @Mid, FinalsGrade = @Fin WHERE SubjectName = @Sub";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@Sub", grade.SubjectName);
                cmd.Parameters.AddWithValue("@Mid", grade.MidtermGrade);
                cmd.Parameters.AddWithValue("@Fin", grade.FinalsGrade);

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
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