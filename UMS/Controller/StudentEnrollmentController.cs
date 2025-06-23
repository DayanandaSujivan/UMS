using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Data;
using UMS.Model;

namespace UMS.Controller
{
    public static class StudentEnrollmentController
    {
        public static bool EnrollStudent(StudentEnrollment enrollment)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = @"INSERT INTO Student_Enrollment (StudentID, CourseID, EnrollmentDate)
                                 VALUES (@StudentID, @CourseID, @EnrollmentDate)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", enrollment.StudentID);
                    cmd.Parameters.AddWithValue("@CourseID", enrollment.CourseID);
                    cmd.Parameters.AddWithValue("@EnrollmentDate", enrollment.EnrollmentDate);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool UpdateEnrollment(StudentEnrollment enrollment)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = @"UPDATE Student_Enrollment 
                                 SET StudentID = @StudentID, CourseID = @CourseID, EnrollmentDate = @EnrollmentDate
                                 WHERE EnrollmentID = @EnrollmentID";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", enrollment.StudentID);
                    cmd.Parameters.AddWithValue("@CourseID", enrollment.CourseID);
                    cmd.Parameters.AddWithValue("@EnrollmentDate", enrollment.EnrollmentDate);
                    cmd.Parameters.AddWithValue("@EnrollmentID", enrollment.EnrollmentID);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool DeleteEnrollment(int enrollmentId)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "DELETE FROM Student_Enrollment WHERE EnrollmentID = @EnrollmentID";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EnrollmentID", enrollmentId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static DataTable GetAllEnrollments()
        {
            var dt = new DataTable();
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = @"SELECT e.EnrollmentID, s.FullName AS StudentName, c.CourseName, e.EnrollmentDate
                                 FROM Student_Enrollment e
                                 JOIN Students s ON e.StudentID = s.Id
                                 JOIN Courses c ON e.CourseID = c.CourseID";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public static Dictionary<int, string> GetStudentList()
        {
            var map = new Dictionary<int, string>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT Id, FullName FROM Students";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        map[reader.GetInt32(0)] = reader.GetString(1);
                    }
                }
            }
            return map;
        }

        public static Dictionary<int, string> GetCourseList()
        {
            var map = new Dictionary<int, string>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT CourseID, CourseName FROM Courses";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        map[reader.GetInt32(0)] = reader.GetString(1);
                    }
                }
            }
            return map;
        }
    }
}
