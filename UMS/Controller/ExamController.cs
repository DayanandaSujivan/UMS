using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Data;
using UMS.Model;

namespace UMS.Controller
{
    public static class ExamController
    {
        public static bool AddExam(Exam exam)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "INSERT INTO Exams (ExamName, SubjectID) VALUES (@ExamName, @SubjectID)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ExamName", exam.ExamName);
                    cmd.Parameters.AddWithValue("@SubjectID", exam.SubjectID);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool UpdateExam(Exam exam)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "UPDATE Exams SET ExamName = @ExamName, SubjectID = @SubjectID WHERE ExamID = @ExamID";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ExamName", exam.ExamName);
                    cmd.Parameters.AddWithValue("@SubjectID", exam.SubjectID);
                    cmd.Parameters.AddWithValue("@ExamID", exam.ExamID);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool DeleteExam(int examId)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "DELETE FROM Exams WHERE ExamID = @ExamID";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ExamID", examId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static List<Exam> GetAllExams()
        {
            var list = new List<Exam>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = @"SELECT e.ExamID, e.ExamName, s.SubjectID, s.SubjectName 
                                 FROM Exams e 
                                 JOIN Subjects s ON e.SubjectID = s.SubjectID";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Exam
                        {
                            ExamID = reader.GetInt32(0),
                            ExamName = reader.GetString(1),
                            SubjectID = reader.GetInt32(2),
                            SubjectName = reader.GetString(3)
                        });
                    }
                }
            }
            return list;
        }

        public static Dictionary<int, string> GetSubjectList()
        {
            var dict = new Dictionary<int, string>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT SubjectID, SubjectName FROM Subjects";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dict[reader.GetInt32(0)] = reader.GetString(1);
                    }
                }
            }
            return dict;
        }
    }
}
