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
    public static class TimetableController
    {
        public static bool AddTimetable(Timetable t)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "INSERT INTO Timetables (SubjectID, RoomID, TimeSlot) VALUES (@SubjectID, @RoomID, @TimeSlot)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SubjectID", t.SubjectID);
                    cmd.Parameters.AddWithValue("@RoomID", t.RoomID);
                    cmd.Parameters.AddWithValue("@TimeSlot", t.TimeSlot);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool UpdateTimetable(Timetable t)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "UPDATE Timetables SET SubjectID = @SubjectID, RoomID = @RoomID, TimeSlot = @TimeSlot WHERE TimetableID = @TimetableID";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SubjectID", t.SubjectID);
                    cmd.Parameters.AddWithValue("@RoomID", t.RoomID);
                    cmd.Parameters.AddWithValue("@TimeSlot", t.TimeSlot);
                    cmd.Parameters.AddWithValue("@TimetableID", t.TimetableID);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool DeleteTimetable(int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "DELETE FROM Timetables WHERE TimetableID = @TimetableID";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TimetableID", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static List<Timetable> GetAllTimetables()
        {
            var list = new List<Timetable>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = @"SELECT t.TimetableID, t.SubjectID, s.SubjectName, t.RoomID, r.RoomName, t.TimeSlot
                                 FROM Timetables t
                                 JOIN Subjects s ON t.SubjectID = s.SubjectID
                                 JOIN Rooms r ON t.RoomID = r.RoomID";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Timetable
                        {
                            TimetableID = reader.GetInt32(0),
                            SubjectID = reader.GetInt32(1),
                            SubjectName = reader.GetString(2),
                            RoomID = reader.GetInt32(3),
                            RoomName = reader.GetString(4),
                            TimeSlot = reader.GetString(5)
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

        public static Dictionary<int, string> GetRoomList()
        {
            var dict = new Dictionary<int, string>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT RoomID, RoomName FROM Rooms";
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
