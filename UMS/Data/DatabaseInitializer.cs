using System;
using System.Data.SQLite;

namespace UMS.Data
{
    public static class DatabaseInitializer
    {
        public static void CreateTables()
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string preRegisterTable = @"
                    CREATE TABLE IF NOT EXISTS pre_register (
                        NIC TEXT NOT NULL PRIMARY KEY,
                        FullName TEXT NOT NULL,
                        Phone INTEGER NOT NULL,
                        Email TEXT NOT NULL,
                        Address TEXT NOT NULL,
                        DOB TEXT,
                        Role TEXT NOT NULL,
                        Status BOOL DEFAULT 0
                    );";

                string usersTable = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT NOT NULL UNIQUE,
                        Password TEXT NOT NULL,
                        Role TEXT NOT NULL
                    );";

                string studentsTable = @"
                    CREATE TABLE IF NOT EXISTS Students (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        UserID INTEGER NOT NULL,
                        NIC TEXT NOT NULL,
                        FullName TEXT NOT NULL,
                        Phone INTEGER NOT NULL,
                        Email TEXT NOT NULL,
                        Address TEXT NOT NULL,
                        DOB TEXT,
                        ProfilePic BLOB,
                        CourseID INTEGER,
                        FOREIGN KEY(UserID) REFERENCES Users(UserID),
                        FOREIGN KEY(CourseID) REFERENCES Courses(CourseID)
                    );";

                string lecturersTable = @"
                    CREATE TABLE IF NOT EXISTS Lecturers (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        UserID INTEGER NOT NULL,
                        NIC TEXT NOT NULL,
                        FullName TEXT NOT NULL,
                        Phone INTEGER NOT NULL,
                        Email TEXT NOT NULL,
                        Address TEXT NOT NULL,
                        DOB TEXT,
                        ProfilePic BLOB,
                        FOREIGN KEY(UserID) REFERENCES Users(UserID)
                     );";

                string adminsTable = @"
                    CREATE TABLE IF NOT EXISTS Admins (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        UserID INTEGER NOT NULL,
                        NIC TEXT NOT NULL,
                        FullName TEXT NOT NULL,
                        Phone INTEGER NOT NULL,
                        Email TEXT NOT NULL,
                        Address TEXT NOT NULL,
                        DOB TEXT,
                        ProfilePic BLOB,
                        FOREIGN KEY(UserID) REFERENCES Users(UserID)
                    );";

                string staffTable = @"
                    CREATE TABLE IF NOT EXISTS Staff (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        UserID INTEGER NOT NULL,
                        NIC TEXT NOT NULL,
                        FullName TEXT NOT NULL,
                        Phone INTEGER NOT NULL,
                        Email TEXT NOT NULL,
                        Address TEXT NOT NULL,
                        DOB TEXT,
                        ProfilePic BLOB,
                        FOREIGN KEY(UserID) REFERENCES Users(UserID)
                    );";

                string coursesTable = @"
                    CREATE TABLE IF NOT EXISTS Courses (
                        CourseID INTEGER PRIMARY KEY AUTOINCREMENT,
                        CourseName TEXT NOT NULL
                    );";

                string subjectsTable = @"
                    CREATE TABLE IF NOT EXISTS Subjects (
                        SubjectID INTEGER PRIMARY KEY AUTOINCREMENT,
                        SubjectName TEXT NOT NULL,
                        CourseID INTEGER NOT NULL,
                        FOREIGN KEY(CourseID) REFERENCES Courses(CourseID)
                    );";

                string lecturerSubjectsTable = @"
                    CREATE TABLE IF NOT EXISTS LecturerSubjects (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        LecturerID INTEGER NOT NULL,
                        SubjectID INTEGER NOT NULL,
                        FOREIGN KEY(LecturerID) REFERENCES Lecturers(Id),
                        FOREIGN KEY(SubjectID) REFERENCES Subjects(SubjectID)
                    );";

                string examsTable = @"
                    CREATE TABLE IF NOT EXISTS Exams (
                        ExamID INTEGER PRIMARY KEY AUTOINCREMENT,
                        ExamName TEXT NOT NULL,
                        SubjectID INTEGER NOT NULL,
                        FOREIGN KEY(SubjectID) REFERENCES Subjects(SubjectID)
                    );";

                string marksTable = @"
                    CREATE TABLE IF NOT EXISTS Marks (
                        MarkID INTEGER PRIMARY KEY AUTOINCREMENT,
                        StudentID INTEGER NOT NULL,
                        ExamID INTEGER NOT NULL,
                        Score INTEGER NOT NULL,
                        FOREIGN KEY(StudentID) REFERENCES Students(Id),
                        FOREIGN KEY(ExamID) REFERENCES Exams(ExamID)
                    );";

                string roomsTable = @"
                    CREATE TABLE IF NOT EXISTS Rooms (
                        RoomID INTEGER PRIMARY KEY AUTOINCREMENT,
                        RoomName TEXT NOT NULL,
                        RoomType TEXT NOT NULL
                    );";

                string timetablesTable = @"
                    CREATE TABLE IF NOT EXISTS Timetables (
                        TimetableID INTEGER PRIMARY KEY AUTOINCREMENT,
                        SubjectID INTEGER NOT NULL,
                        TimeSlot TEXT NOT NULL,
                        RoomID INTEGER NOT NULL,
                        FOREIGN KEY(SubjectID) REFERENCES Subjects(SubjectID),
                        FOREIGN KEY(RoomID) REFERENCES Rooms(RoomID)
                    );";
                string studentEnrollmentTable = @"
                    CREATE TABLE IF NOT EXISTS Student_Enrollment (
                        EnrollmentID INTEGER PRIMARY KEY AUTOINCREMENT,
                        StudentID INTEGER NOT NULL,
                        CourseID INTEGER NOT NULL,
                        EnrollmentDate TEXT,
                        FOREIGN KEY(StudentID) REFERENCES Students(Id),
                        FOREIGN KEY(CourseID) REFERENCES Courses(CourseID)
                    );";

                
                string[] tableQueries = {
                    usersTable, studentsTable, lecturersTable,
                    adminsTable, staffTable, coursesTable,
                    subjectsTable, lecturerSubjectsTable, examsTable,
                    marksTable, roomsTable, timetablesTable,
                    studentEnrollmentTable, 
                    preRegisterTable
                };

                foreach (string query in tableQueries)
                {
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
