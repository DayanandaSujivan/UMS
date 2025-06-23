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
    public static class CourseController
    {
        public static bool AddCourse(Course course)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "INSERT INTO Courses (CourseName) VALUES (@CourseName)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool UpdateCourse(Course course)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "UPDATE Courses SET CourseName = @CourseName WHERE CourseID = @CourseID";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                    cmd.Parameters.AddWithValue("@CourseID", course.CourseID);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool DeleteCourse(int courseId)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "DELETE FROM Courses WHERE CourseID = @CourseID";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseID", courseId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static List<Course> GetAllCourses()
        {
            var courses = new List<Course>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM Courses";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        courses.Add(new Course
                        {
                            CourseID = reader.GetInt32(0),
                            CourseName = reader.GetString(1)
                        });
                    }
                }
            }
            return courses;
        }
    }
}
