using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WebApplication.DTOs;
using WebApplication.Models;

namespace WebApplication.Repositories
{
    public class BlurayRepository
    
    {
        private MySqlConnection connection;
        /// <summary>
        /// Consctructeur par défaut
        /// </summary>
        public BlurayRepository(){ }

        public List<Bluray> GetListeBluRay()
        {
            List<Bluray> listBluRay = new List<Bluray>();

            try
            {
                connection = new MySqlConnection("Server=localhost;User Id=root;Password=4VzwvXLf;Database=bluray");
                connection.Open();
                // Define a query returning a single row result set
                MySqlCommand command = new MySqlCommand("SELECT b.id, titre, dateSortie, duree, version, image FROM bluray b", connection);
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
                        Version = dr[4].ToString(),
                        image = dr[5].ToString()
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

        public void AddBluRay(Bluray formModel)
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;User Id=root;Password=4VzwvXLf;Database=bluray");
                connection.Open();
                
                MySqlCommand command = new MySqlCommand("INSERT INTO `bluray`(`id`, `titre`, `duree`, `dateSortie`, `version`, `image`) VALUES (?1, ?2, ?3, ?4, ?5,'https://fr.web.img6.acsta.net/r_654_368/newsv7/15/10/19/21/14/237930.jpg'); INSERT INTO `personne`", connection);
                command.Parameters.AddWithValue("1", formModel.Id);
                command.Parameters.AddWithValue("2", formModel.Titre);
                command.Parameters.AddWithValue("3", formModel.Duree);
                command.Parameters.AddWithValue("4", formModel.DateSortie);
                command.Parameters.AddWithValue("5", formModel.Version);
                command.Parameters.AddWithValue("acteurs", formModel.Acteurs);
                command.ExecuteNonQuery();

            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public void DeleteBluRay(int id)
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;User Id=root;Password=4VzwvXLf;Database=bluray");
                connection.Open();
                
                MySqlCommand command = new MySqlCommand("DELETE FROM bluray WHERE id=?id", connection);
                command.Parameters.AddWithValue("id", id);
                command.ExecuteNonQuery();

            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
    }
}