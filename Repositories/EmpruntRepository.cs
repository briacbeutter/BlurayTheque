using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WebApplication.DTOs;

namespace WebApplication.Repositories
{
    public class EmpruntRepository
    {

        public List<Emprunteur> getBaseUrl()
        {
            MySqlConnection connection = null;
            List<Emprunteur> emprunteurs = new List<Emprunteur>();

            try
            {
                connection = new MySqlConnection("Server=localhost;User Id=root;Password=4VzwvXLf;Database=bluray");
                connection.Open();

                MySqlCommand command =
                    new MySqlCommand(
                        "SELECT nom,baseUrl FROM sourceEmprunt",
                        connection);
                MySqlDataReader dr = command.ExecuteReader();

                // Output rows
                while (dr.Read())
                {
                    emprunteurs.Add(new Emprunteur
                        {
                            Nom = dr[0].ToString(),
                            BaseUrl = dr[1].ToString()

                        }
                    );
                }
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return emprunteurs;
        }
        
    }
}