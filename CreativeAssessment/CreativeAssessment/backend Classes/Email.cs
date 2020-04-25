using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using CreativeAssessment.backend_Classes.Entities;
using SQLite;
using System.Net.Mail;
using System.Linq;

namespace CreativeAssessment.backendClasses
{
    public class EmailHandler
    {

        public SmtpClient InitialiseEmailServer()
        {
            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
            smtpServer.Port = 587;
            smtpServer.Host = "smtp.gmail.com";
            smtpServer.EnableSsl = true;
            smtpServer.UseDefaultCredentials = false;
            //can edit this to take in the email and password as args, maybe a password dialogue in the future?
            smtpServer.Credentials = new System.Net.NetworkCredential("creativeassessmenttest@gmail.com", "gyohcgojkuovroal");

            return smtpServer;
        }

        public MailMessage InitialiseEmail()
        {
            var email = new MailMessage();
            // can we get the uni to provide a server

            email.From = new MailAddress("creativeassessmenttest@gmail.com");
            //email.To.Add(student.Email);

            //when we have it set this to the project/assessment name
            email.Subject = "Assessment Marks";

            return email;
        }

        public void SendEmails(List<Student> students, List<Entities.DetailedFeedback> detailedFeedbackMatrix)
        {
            var smtpServer = InitialiseEmailServer();

            var studentsMarks = GetStudentsMarks(students, detailedFeedbackMatrix);

            foreach (var student in students)
            {
                try
                {
                    var email = InitialiseEmail();

                    email.To.Add(student.Email);
                    //my email for testing
                    //email.To.Add("40406489@live.napier.ac.uk");

                    email.Body = GenerateResultsEmail(studentsMarks[student.MatriculationNumber]
                    //,assessmentID
                    , detailedFeedbackMatrix);

                    smtpServer.Send(email);

                    student.FeedbackSent = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            using (SQLiteConnection db = new SQLiteConnection(App.FilePath))
            {
                db.UpdateAll(students);
            }

        }

        public Dictionary<int, List<CriterionMark>> GetStudentsMarks(List<Student> students, List<Entities.DetailedFeedback> detailedFeedbackMatrix)
        {
            using (SQLiteConnection db = new SQLiteConnection(App.FilePath))
            {
                var studentsMarks = new Dictionary<int, List<CriterionMark>>();

                foreach (var student in students)
                {
                    studentsMarks.Add(student.MatriculationNumber, db.Table<CriterionMark>().Where(x => x.StudentID == student.MatriculationNumber).ToList());
                }

                return studentsMarks;
            }
        }


        public static string GenerateResultsEmail(List<CriterionMark> studentMarks, List<Entities.DetailedFeedback> detailedFeedbackMatrix)
        //,int assessmentID)
        {

            var emailString = $@"Marks:
{detailedFeedbackMatrix[0].Criterion}
Mark: {studentMarks[0].Mark}%
{Feedback.ReturnDetailedFeedback(studentMarks[0].Mark, 0, detailedFeedbackMatrix)}
Additional Comments: {studentMarks[0].Comments}

{detailedFeedbackMatrix[1].Criterion}
Mark: {studentMarks[1].Mark}%
{Feedback.ReturnDetailedFeedback(studentMarks[1].Mark, 1, detailedFeedbackMatrix)}
Additional Comments: {studentMarks[1].Comments}

{detailedFeedbackMatrix[2].Criterion}
Mark: {studentMarks[2].Mark}%
{Feedback.ReturnDetailedFeedback(studentMarks[2].Mark, 2, detailedFeedbackMatrix)}
Additional Comments: {studentMarks[2].Comments}

{detailedFeedbackMatrix[3].Criterion}
: {studentMarks[3].Mark}%
{Feedback.ReturnDetailedFeedback(studentMarks[3].Mark, 3, detailedFeedbackMatrix)}
Additional Comments: {studentMarks[3].Comments}

{detailedFeedbackMatrix[4].Criterion}
Mark: {studentMarks[4].Mark}%
{Feedback.ReturnDetailedFeedback(studentMarks[4].Mark, 4, detailedFeedbackMatrix)}
Additional Comments: {studentMarks[4].Comments}

{detailedFeedbackMatrix[5].Criterion}
Mark: {studentMarks[5].Mark}%
{Feedback.ReturnDetailedFeedback(studentMarks[5].Mark, 5, detailedFeedbackMatrix)}
Additional Comments: {studentMarks[5].Comments}";

            return emailString;
        }
    }
}
