using System;
using Microsoft.Data.SqlClient;

namespace GradeComputationDataServices
{
    public class GradeSQLData
    {
        private static string connString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=StudentGradesDB;Integrated Security=True;TrustServerCertificate=True;";

        public static void SaveToDatabase()
        {
            SqlConnection sqlConnection = new SqlConnection(connString);

            string insertStatement = "INSERT INTO GradesPup (SubjectName, Sw1, Sw2, Qz1, Qz2, Assign, Lab, Exam, MidtermGrade, FinalsGrade) " +
                                     "VALUES (@SubjectName, @Sw1, @Sw2, @Qz1, @Qz2, @Assign, @Lab, @Exam, @MidtermGrade, @FinalsGrade)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@SubjectName", GradeData.subjectName);
            insertCommand.Parameters.AddWithValue("@Sw1", GradeData.sw1.ToString());
            insertCommand.Parameters.AddWithValue("@Sw2", GradeData.sw2.ToString());
            insertCommand.Parameters.AddWithValue("@Qz1", GradeData.qz1.ToString());
            insertCommand.Parameters.AddWithValue("@Qz2", GradeData.qz2.ToString());
            insertCommand.Parameters.AddWithValue("@Assign", GradeData.assign.ToString());
            insertCommand.Parameters.AddWithValue("@Lab", GradeData.lab.ToString());
            insertCommand.Parameters.AddWithValue("@Exam", GradeData.exam.ToString());
            insertCommand.Parameters.AddWithValue("@MidtermGrade", GradeData.midtermGrade.ToString());
            insertCommand.Parameters.AddWithValue("@FinalsGrade", GradeData.finalsGrade.ToString());

            sqlConnection.Open();
            insertCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}