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
    public static class SubjectController
    {
        public static bool AddSubject(Subject subject)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "INSERT INTO Subjects (SubjectName, CourseID) VALUES (@SubjectName, @CourseID)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SubjectName", subject.SubjectName);
                    cmd.Parameters.AddWithValue("@CourseID", subject.CourseID);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool UpdateSubject(Subject subject)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "UPDATE Subjects SET SubjectName = @SubjectName, CourseID = @CourseID WHERE SubjectID = @SubjectID";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SubjectName", subject.SubjectName);
                    cmd.Parameters.AddWithValue("@CourseID", subject.CourseID);
                    cmd.Parameters.AddWithValue("@SubjectID", subject.SubjectID);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool DeleteSubject(int subjectID)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "DELETE FROM Subjects WHERE SubjectID = @SubjectID";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SubjectID", subjectID);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static List<Subject> GetAllSubjects()
        {
            var list = new List<Subject>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = @"SELECT s.SubjectID, s.SubjectName, s.CourseID, c.CourseName 
                                 FROM Subjects s
                                 JOIN Courses c ON s.CourseID = c.CourseID";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Subject
                        {
                            SubjectID = reader.GetInt32(0),
                            SubjectName = reader.GetString(1),
                            CourseID = reader.GetInt32(2),
                            CourseName = reader.GetString(3)
                        });
                    }
                }
            }
            return list;
        }

        public static Dictionary<int, string> GetCourseList()
        {
            var dict = new Dictionary<int, string>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT CourseID, CourseName FROM Courses";
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
