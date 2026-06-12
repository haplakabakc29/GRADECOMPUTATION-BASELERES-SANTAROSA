using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace GRADECOMPUTATIONAPI
{
    public class DModels
    {
        public int S_ID { get; set; }
        public string StudentName { get; set; }
        public string SubjectName { get; set; }
        public double Sw1 { get; set; }
        public double Sw2 { get; set; }
        public double Qz1 { get; set; }
        public double Qz2 { get; set; }
        public double Assign { get; set; }
        public double Lab { get; set; }
        public double Exam { get; set; }
        public double MidtermGrade { get; set; }
        public double FinalsGrade { get; set; }
    }

    public class GradeCalculator
    {
        private static string connString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=StudentGradesDB;Integrated Security=True;TrustServerCertificate=True;";

        public List<DModels> GetGradeLogs()
        {
            List<DModels> recordsList = new List<DModels>();
            string selectQuery = "SELECT * FROM GradesPup";

            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(selectQuery, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DModels log = new DModels();
                    log.S_ID = Convert.ToInt32(reader["S_ID"]);
                    log.StudentName = reader["StudentName"].ToString();
                    log.SubjectName = reader["SubjectName"].ToString();
                    log.Sw1 = Convert.ToDouble(reader["Sw1"]);
                    log.Sw2 = Convert.ToDouble(reader["Sw2"]);
                    log.Qz1 = Convert.ToDouble(reader["Qz1"]);
                    log.Qz2 = Convert.ToDouble(reader["Qz2"]);
                    log.Assign = Convert.ToDouble(reader["Assign"]);
                    log.Lab = Convert.ToDouble(reader["Lab"]);
                    log.Exam = Convert.ToDouble(reader["Exam"]);
                    log.MidtermGrade = Convert.ToDouble(reader["MidtermGrade"]);
                    log.FinalsGrade = Convert.ToDouble(reader["FinalsGrade"]);
                    recordsList.Add(log);
                }
            }
            return recordsList;
        }

        public DModels GetGradeById(int id)
        {
            DModels log = null;
            string selectQuery = "SELECT * FROM GradesPup WHERE S_ID = @id";

            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(selectQuery, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    log = new DModels();
                    log.S_ID = Convert.ToInt32(reader["S_ID"]);
                    log.StudentName = reader["StudentName"].ToString();
                    log.SubjectName = reader["SubjectName"].ToString();
                    log.Sw1 = Convert.ToDouble(reader["Sw1"]);
                    log.Sw2 = Convert.ToDouble(reader["Sw2"]);
                    log.Qz1 = Convert.ToDouble(reader["Qz1"]);
                    log.Qz2 = Convert.ToDouble(reader["Qz2"]);
                    log.Assign = Convert.ToDouble(reader["Assign"]);
                    log.Lab = Convert.ToDouble(reader["Lab"]);
                    log.Exam = Convert.ToDouble(reader["Exam"]);
                    log.MidtermGrade = Convert.ToDouble(reader["MidtermGrade"]);
                    log.FinalsGrade = Convert.ToDouble(reader["FinalsGrade"]);
                }
            }
            return log;
        }

        public bool Register(DModels newGrade)
        {
            string insertQuery = "INSERT INTO GradesPup (StudentName, SubjectName, Sw1, Sw2, Qz1, Qz2, Assign, Lab, Exam, MidtermGrade, FinalsGrade) " +
                                 "VALUES (@StudentName, @SubjectName, @Sw1, @Sw2, @Qz1, @Qz2, @Assign, @Lab, @Exam, @MidtermGrade, @FinalsGrade)";

            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(insertQuery, connection);
                cmd.Parameters.AddWithValue("@StudentName", newGrade.StudentName);
                cmd.Parameters.AddWithValue("@SubjectName", newGrade.SubjectName);
                cmd.Parameters.AddWithValue("@Sw1", newGrade.Sw1);
                cmd.Parameters.AddWithValue("@Sw2", newGrade.Sw2);
                cmd.Parameters.AddWithValue("@Qz1", newGrade.Qz1);
                cmd.Parameters.AddWithValue("@Qz2", newGrade.Qz2);
                cmd.Parameters.AddWithValue("@Assign", newGrade.Assign);
                cmd.Parameters.AddWithValue("@Lab", newGrade.Lab);
                cmd.Parameters.AddWithValue("@Exam", newGrade.Exam);
                cmd.Parameters.AddWithValue("@MidtermGrade", newGrade.MidtermGrade);
                cmd.Parameters.AddWithValue("@FinalsGrade", newGrade.FinalsGrade);

                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool UpdateUser(DModels updatedAccount)
        {
            string updateQuery = "UPDATE GradesPup SET " +
                                 "StudentName = @StudentName, " +
                                 "SubjectName = @SubjectName, " +
                                 "Sw1 = @Sw1, " +
                                 "Sw2 = @Sw2, " +
                                 "Qz1 = @Qz1, " +
                                 "Qz2 = @Qz2, " +
                                 "Assign = @Assign, " +
                                 "Lab = @Lab, " +
                                 "Exam = @Exam, " +
                                 "MidtermGrade = @MidtermGrade, " +
                                 "FinalsGrade = @FinalsGrade " +
                                 "WHERE S_ID = @id";

            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(updateQuery, connection);
                cmd.Parameters.AddWithValue("@id", updatedAccount.S_ID);
                cmd.Parameters.AddWithValue("@StudentName", updatedAccount.StudentName);
                cmd.Parameters.AddWithValue("@SubjectName", updatedAccount.SubjectName);
                cmd.Parameters.AddWithValue("@Sw1", updatedAccount.Sw1);
                cmd.Parameters.AddWithValue("@Sw2", updatedAccount.Sw2);
                cmd.Parameters.AddWithValue("@Qz1", updatedAccount.Qz1);
                cmd.Parameters.AddWithValue("@Qz2", updatedAccount.Qz2);
                cmd.Parameters.AddWithValue("@Assign", updatedAccount.Assign);
                cmd.Parameters.AddWithValue("@Lab", updatedAccount.Lab);
                cmd.Parameters.AddWithValue("@Exam", updatedAccount.Exam);
                cmd.Parameters.AddWithValue("@MidtermGrade", updatedAccount.MidtermGrade);
                cmd.Parameters.AddWithValue("@FinalsGrade", updatedAccount.FinalsGrade);

                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool RemoveUser(int id)
        {
            string deleteQuery = "DELETE FROM GradesPup WHERE S_ID = @id";

            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(deleteQuery, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}