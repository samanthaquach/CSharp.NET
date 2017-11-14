using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using Form_Submission.Models;


namespace Form_Submission.Factories {


    public class FormFactory {
        // ALL THE FACTORIES
    }

//             public void Add(User item)
//         {
//             using (IDbConnection dbConnection = Connection) {
//                 string query =  "INSERT INTO users (user_name, email, password, created_at, updated_at) VALUES (@Name, @Email, @Password, NOW(), NOW())";
//                 dbConnection.Open();
//                 dbConnection.Execute(query, item);
//             }
//         }
//         public IEnumerable<User> FindAll()
//         {
//             using (IDbConnection dbConnection = Connection)
//             {
//                 dbConnection.Open();
//                 return dbConnection.Query<User>("SELECT * FROM users");
//             }
//         }
//         public User FindByID(int id)
//         {
//             using (IDbConnection dbConnection = Connection)
//             {
//                 dbConnection.Open();
//                 return dbConnection.Query<User>("SELECT * FROM users WHERE id = @Id", new { Id = id }).FirstOrDefault();
//             }
//         }
}