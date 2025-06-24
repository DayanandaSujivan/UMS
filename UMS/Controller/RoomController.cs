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
    public static class RoomController
    {
        public static bool AddRoom(Room room)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "INSERT INTO Rooms (RoomName, RoomType) VALUES (@RoomName, @RoomType)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RoomName", room.RoomName);
                    cmd.Parameters.AddWithValue("@RoomType", room.RoomType);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool UpdateRoom(Room room)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "UPDATE Rooms SET RoomName = @RoomName, RoomType = @RoomType WHERE RoomID = @RoomID";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RoomName", room.RoomName);
                    cmd.Parameters.AddWithValue("@RoomType", room.RoomType);
                    cmd.Parameters.AddWithValue("@RoomID", room.RoomID);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool DeleteRoom(int roomId)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "DELETE FROM Rooms WHERE RoomID = @RoomID";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RoomID", roomId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static List<Room> GetAllRooms()
        {
            var list = new List<Room>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT RoomID, RoomName, RoomType FROM Rooms";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Room
                        {
                            RoomID = reader.GetInt32(0),
                            RoomName = reader.GetString(1),
                            RoomType = reader.GetString(2)
                        });
                    }
                }
            }
            return list;
        }
    }
}
