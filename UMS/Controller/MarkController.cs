using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMS.Controller;
using UMS.Data;
using UMS.Model;
using UMS.View;

namespace UMS.Controller
{
    public static class MarkController
    {
        public static bool AddMark(Mark mark)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "INSERT INTO Marks (StudentID, ExamID, Score) VALUES (@StudentID, @ExamID, @Score)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", mark.StudentID);
                    cmd.Parameters.AddWithValue("@ExamID", mark.ExamID);
                    cmd.Parameters.AddWithValue("@Score", mark.Score);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool UpdateMark(Mark mark)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "UPDATE Marks SET StudentID = @StudentID, ExamID = @ExamID, Score = @Score WHERE MarkID = @MarkID";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", mark.StudentID);
                    cmd.Parameters.AddWithValue("@ExamID", mark.ExamID);
                    cmd.Parameters.AddWithValue("@Score", mark.Score);
                    cmd.Parameters.AddWithValue("@MarkID", mark.MarkID);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool DeleteMark(int markID)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "DELETE FROM Marks WHERE MarkID = @MarkID";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MarkID", markID);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static List<Mark> GetAllMarks()
        {
            var list = new List<Mark>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = @"SELECT m.MarkID, m.StudentID, s.FullName, m.ExamID, e.ExamName, m.Score
                                 FROM Marks m
                                 JOIN Students s ON m.StudentID = s.Id
                                 JOIN Exams e ON m.ExamID = e.ExamID";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Mark
                        {
                            MarkID = reader.GetInt32(0),
                            StudentID = reader.GetInt32(1),
                            StudentName = reader.GetString(2),
                            ExamID = reader.GetInt32(3),
                            ExamName = reader.GetString(4),
                            Score = reader.GetInt32(5)
                        });
                    }
                }
            }
            return list;
        }

        public static int GetStudentIdByUserId(int userId)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT Id FROM Students WHERE UserID = @UserID";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
        }


        public static List<Mark> GetMarksByStudentID(int studentId)
        {
            var list = new List<Mark>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = @"SELECT m.MarkID, s.Id AS StudentID, s.FullName AS StudentName, 
                         e.ExamID, e.ExamName, m.Score
                         FROM Marks m
                         JOIN Students s ON m.StudentID = s.Id
                         JOIN Exams e ON m.ExamID = e.ExamID
                         WHERE s.Id = @StudentID";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Mark
                            {
                                MarkID = reader.GetInt32(0),
                                StudentID = reader.GetInt32(1),
                                StudentName = reader.GetString(2),
                                ExamID = reader.GetInt32(3),
                                ExamName = reader.GetString(4),
                                Score = reader.GetInt32(5)
                            });
                        }
                    }
                }
            }
            return list;
        }



        public static Dictionary<int, string> GetStudentList()
        {
            var dict = new Dictionary<int, string>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT Id, FullName FROM Students";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        dict[reader.GetInt32(0)] = reader.GetString(1);
                }
            }
            return dict;
        }

        public static Dictionary<int, string> GetExamList()
        {
            var dict = new Dictionary<int, string>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT ExamID, ExamName FROM Exams";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        dict[reader.GetInt32(0)] = reader.GetString(1);
                }
            }
            return dict;
        }
    }
}
