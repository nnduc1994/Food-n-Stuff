using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodnStuff.Model
{
    public class VoteManagement
    {
        //Create new row to vote table,
        public static void CreateVote(int UserID, int RecipeID, int Vote) {
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            string id = "";
            string command = "SELECT * FROM Vote Where UserID=" + UserID + " AND RecipeID=" + RecipeID;
            var reader = myDatabase.ExcuteQuery(command);
            reader.Read();
            if (reader.HasRows == true)
            {
                id = reader["ID"].ToString();
                command = "UPDATE Vote SET Vote='" + Vote + "' WHERE ID =" + id + ";";
                myDatabase.ExcuteNonQuery(command);
                myDatabase.CloseConnection();
            }
            else
            {
                command = "INSERT INTO Vote (RecipeID,UserID,Vote) VALUES ('" + RecipeID + "','" + UserID + "','" + Vote + "');";
                myDatabase.ExcuteNonQuery(command);
                myDatabase.CloseConnection();
            }
        }

        public static int GetRecipeVote(int RecipeID) {
            int averageVote = 0;
            int count = 0;
            int sum = 0;
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            string command = "SELECT * FROM Vote Where RecipeID=" + RecipeID + "";
            var reader = myDatabase.ExcuteQuery(command);
            bool notEOF = false;
            notEOF = reader.Read();
            while (notEOF)
            {
                count++;
                sum = sum+Convert.ToInt32(reader["Vote"]);
                notEOF = reader.Read();
            }
            myDatabase.CloseConnection();
            averageVote = sum / count;
            return averageVote;
        }

    }
}