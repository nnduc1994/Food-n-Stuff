using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace FoodnStuff.Model
{
    public class Email
    {
        public static bool SendEmail(string sendEmail, string sender, string recipientEmail, string recipient, string title, string message)
        {
            try
            {
                MailAddress to;
                MailAddress from;
                if (sender != null)
                    from = new MailAddress(sendEmail.Trim(), sender.Trim());
                else
                    from = new MailAddress(sendEmail.Trim());
                if (recipient != null)
                    to = new MailAddress(recipientEmail.Trim(), recipient.Trim());
                else
                    to = new MailAddress(recipientEmail.Trim());

                MailMessage myEmail = new MailMessage(from, to);
             

             
                myEmail.Subject = title.Trim();
                myEmail.IsBodyHtml = false;
                myEmail.BodyEncoding = Encoding.GetEncoding("iso-8859-1");
                myEmail.SubjectEncoding = Encoding.GetEncoding("iso-8859-1");
                myEmail.Body = message;

                //send with GMail SMTP server
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("foodnstuffdemo@gmail.com", "rt88kesa2012");
                client.Send(myEmail);

                GC.Collect();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static void sendRemindEmail(int userID) {
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            string command = "SELECT * FROM UserTable Where ID=" + userID + ";";
            var reader = myDatabase.ExcuteQuery(command);
            reader.Read();

            User userObj = new User();
            userObj.Name = reader["Name"].ToString();
            userObj.Email = reader["Email"].ToString();

            List<Ingredient> expiredIngredientList = Model.StorageManagement.GetExpiredIngredient(userID);

            string message = "Hi, " + userObj.Name + " you have some food will expired today. Take a look" + System.Environment.NewLine + System.Environment.NewLine;
            foreach (Ingredient ing in expiredIngredientList) {
                message += ing.Amount + " " + ing.Unit + " " + ing.Name + " Expired day " + ing.ExpiredDay + System.Environment.NewLine;
            }

            Email.SendEmail("foodnstuffdemo@gmail.com", "FoodnStuff@support", userObj.Email, userObj.Name, "Expired food reminder", message);

            myDatabase.CloseConnection();
        }
    }
}