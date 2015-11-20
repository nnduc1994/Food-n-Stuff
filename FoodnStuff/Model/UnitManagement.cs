using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodnStuff.Model
{
    public class UnitManagement
    {
        public static List<Unit> ListAllUnit()
        {
            Database myDatbase = new Database();
            myDatbase.ReturnConnection();
            string command = "SELECT * FROM Unit";
            var reader = myDatbase.ExcuteQuery(command);
            List<Unit> returnUnitList = new List<Unit>();

            bool EOF = reader.Read();
            while (EOF)
            {
                Unit unitObj = new Unit();
                unitObj.Name = reader["Name"].ToString();
                unitObj.ID = int.Parse(reader["ID"].ToString());
                returnUnitList.Add(unitObj);
                EOF = reader.Read();
            }
            myDatbase.CloseConnection();
            return returnUnitList;
        }
    }

    //Business Object
    public class Unit
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }
}