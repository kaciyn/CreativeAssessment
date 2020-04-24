using System;
using System.Security.Cryptography.X509Certificates;
using CreativeAssessment.backend_Classes.Entities;
using SQLite;

namespace CreativeAssessment.backendClasses
{
    public class EmailHandler
    {

        public void SendEmails() { }
        public static string GenerateResultsEmail(int studentID)
        //,int assessmentID)
        {
            using (SQLiteConnection db = new SQLiteConnection(App.FilePath))
            {
                db.Table<CriterionMark>();
            }

            return "";
        }
    }
}
