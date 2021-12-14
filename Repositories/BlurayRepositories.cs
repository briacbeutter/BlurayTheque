using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WebApplication.DTOs;

namespace WebApplication.Repositories
{
    public class BlurayRepository
    
    {
        /// <summary>
        /// Consctructeur par défaut
        /// </summary>
        public BlurayRepository(){ }

        public List<Bluray> GetListeBluRay()
        {
            MySqlConnection connection = null;
            List<Bluray> listBluRay = new List<Bluray>();

            try
            {
                connection = new MySqlConnection("Server=localhost;User Id=root;Password=root;Database=bluray");
                connection.Open();
                // Define a query returning a single row result set
                MySqlCommand command = new MySqlCommand("SELECT b.id, titre, dateSortie, duree, version FROM bluray b", connection);
                // Execute the query and obtain a result set
                MySqlDataReader dr = command.ExecuteReader();

                // Output rows
                while (dr.Read())
                {
                    listBluRay.Add(new Bluray
                    {
                        Id = int.Parse(dr[0].ToString()),
                        Titre = dr[1].ToString(),
                        DateSortie = (DateTime) dr[2],
                        Duree = TimeSpan.Parse(dr[3].ToString()),
                        Version = dr[4].ToString()
                    });
                }
            }
            finally
            {
                if(connection != null)
                {
                    connection.Close();
                }
            }
            return listBluRay;
        }
        
    }
}