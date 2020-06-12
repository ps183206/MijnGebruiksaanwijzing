using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using System.Data;
using System.Data.SqlClient;

namespace MijnGebruiksaanwijzing.Classes
{
    class DatabaseConnection
    {
        MySqlConnection conn =
            new MySqlConnection("Server=localhost;Database=mijngebruiksaanwijzing;Uid=root;Pwd=");
        int role = 1;

        public void AddCard(string naam, string achternaam, string username, string password, bool admin)
        {
            if(admin == true)
            {
                role = 0;
            }            
            conn.Open();
            MySqlCommand command = conn.CreateCommand();

            command.CommandText = "INSERT INTO `users` (`UserID`, `FirstName`, `LastName`, `UserName`, `Password`, `Role`) VALUES(NULL, '" + naam + "', '" + achternaam + "', '" + username + "', '" + password + "', '" + role + "');";
            command.ExecuteReader();

            conn.Close();

        }

        public void GetRedCardsList()
        {
            //List<Card> redCards = new List<Card>();

            //foreach (DataRow dr in dt.Rows)  // dt is a DataTable
            //{
            //    redCards.Add(new Card { ID = int.Parse(dr["CardID"].ToString()), Color = dr["CardColor"].ToString(), Type = dr["CardType"].ToString(), Content = dr["CardDesc"].ToString() });
            //}
        }
    }
}
