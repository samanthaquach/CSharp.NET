using System;
using DbConnection;
// using MySql.Data.MySqlClient;
// using MySql.Data;
using System.Collections.Generic;
// using System.Data;

namespace CRUD

{
    class Program
    {
        public static void ReadData()
        {
            // ------------------- Showing Users: 'x' is each user in Users --------------

            var Users = DbConnector.Query("SELECT * FROM USERS ");
            foreach (var x in Users)
            {
                Console.WriteLine("{0,9} {1,9} {2,9}", x["FirstName"],x["LastName"],x["FavoriteNumber"]);
            }
            


        }
        // ---------- Creating Data ----------

        public static void CreateData()
        {
            Console.WriteLine("Enter First Name: ");
            string first = Console.ReadLine();
            Console.WriteLine("Enter Last Name: ");
            string last = Console.ReadLine();
            Console.WriteLine("Enter Favorite Number: ");
            int FavoriteNumber = Convert.ToInt32(Console.ReadLine());
            
            try
            {
                DbConnector.Execute($"INSERT INTO Users (FirstName, LastName, FavoriteNumber)Values('{first}', '{last}', {FavoriteNumber})");
                Console.WriteLine(" ========= You have successfully added! ========");
            }
            
            catch
            {
                Console.WriteLine("======== I N V A L I D ! =========");
            }

        }

        // ------------------- UPDATE ------------------
        public static void UpdateData()
        {   
            Console.WriteLine("Enter User ID: ");
            int userID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter First Name: ");
            string first = Console.ReadLine();
            Console.WriteLine("Enter Last Name: ");
            string last = Console.ReadLine();
            Console.WriteLine("Enter Favorite Number: ");
            int FavoriteNumber = Convert.ToInt32(Console.ReadLine());

        DbConnector.Execute($"UPDATE Users SET FirstName='{first}', LastName='{last}', FavoriteNumber='{FavoriteNumber}' WHERE idUsers = {userID}; ");
        }

        // ---------------- Destroy --------------------
        public static void DestroyData()
        {
            Console.WriteLine("Enter User ID: ");
            try
            {

            int userID = Convert.ToInt32(Console.ReadLine());
     
            DbConnector.Execute($" DELETE FROM consoleDB.Users WHERE idUsers = {userID}; ");
            Console.WriteLine("========= Delete Success =========");
            }

            catch
            {
                Console.WriteLine("You did not enter a Valid ID");
            }
        }


        static void Main(string[] args)
        {
            // ---------------- DISPLAYING ALL CRUD OPERATIONS --------------
            
            // CreateData();
            UpdateData();
            // DestroyData();
            ReadData();
        }



    
    }

}