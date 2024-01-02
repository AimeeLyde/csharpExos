using System;
using System;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Ocsp;

namespace ExosCs
{
	public class Connexion
	{
        private MySqlConnection connexion;
        private string connectionString;

        public Connexion()
        {
            // Initialisez la chaîne de connexion dans le constructeur
            connectionString = "SERVER=cl1-sql10.phpnet.org;DATABASE=univcergy15;UID=univcergy15;PASSWORD=cmKghpYyM3I";
            connexion = new MySqlConnection(connectionString);
        }
   
        public void ConnectToDB()
        {
            try
            {
                connexion.Open();
                Console.WriteLine("Connexion à la base de données réussie.");
               
                
                //commandes SQL


                //connexion.Close();
                //Console.WriteLine("Connexion fermée.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur de connexion : {ex.Message}");
            }
        }

        public void CreateTable(string req)
        {
            MySqlCommand cmd = connexion.CreateCommand();
            cmd.CommandText = req;
            cmd.ExecuteNonQuery();
        }

        //public void InsertIntoContact()
        //{
        //    MySqlCommand cmd = connexion.CreateCommand();
        //    cmd.CommandText = "INSERT INTO contact (id, name, tel) VALUES(@id, @name, @tel)";
        //    cmd.Parameters.AddWithValue("@id", contact.Id);
        //    cmd.Parameters.AddWithValue("@name", contact.Name);
        //    cmd.Parameters.AddWithValue("@tel", contact.Tel);
        //}

    }
}

