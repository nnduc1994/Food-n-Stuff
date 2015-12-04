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

            //First need to query from the table if there is a row with the same UserID and RecipeID from parameters
            //If no use command INSERT

            //If not mean already exist vote from user, use UPDATE command
        }

        public int GetRecipeVote(int RecipeID) {
            int averageVote = 0;

            //This will contain all the vote belong to this recipe
            List<int> AllVote = new List<int>();

            //First get all vote belong to this recipe then add it to AllVote list, use AllVote.Add() function to add
            // new item to the list

            //Then you will need to calculate the average vote from the list and return it
            
            return averageVote;
        }

    }
}