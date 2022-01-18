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
                MySqlCommand command = new MySqlCommand("SELECT b.id, titre, dateSortie, duree, version, disponible, emprunt FROM bluray b", connection);
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
                        Emprunt = (dr[6].ToString().Equals("False")),
                        Disponible = (!dr[5].ToString().Equals("False"))
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
        
        public Bluray GetLastBluRay()
        {
            Bluray lastBluray = new Bluray();
            
            try
            {
                connection = new MySqlConnection("Server=localhost;User Id=root;Password=4VzwvXLf;Database=bluray");
                connection.Open();
                
                MySqlCommand command = new MySqlCommand("SELECT b.id, titre, dateSortie, duree, version FROM bluray b ORDER BY id DESC LIMIT 1", connection);
                MySqlDataReader dr = command.ExecuteReader();
                
                while (dr.Read())
                {
                    lastBluray.Id = int.Parse(dr[0].ToString());
                    lastBluray.Titre = dr[1].ToString();
                    lastBluray.DateSortie = (DateTime) dr[2];
                    lastBluray.Duree = TimeSpan.Parse(dr[3].ToString());
                    lastBluray.Version = dr[4].ToString();
                }
            }
            finally
            {
                if(connection != null)
                {
                    connection.Close();
                }
            }
            return lastBluray;
        }

        public void AddBluRay(Bluray formModel)
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;User Id=root;Password=4VzwvXLf;Database=bluray");
                connection.Open();
                MySqlCommand command = new MySqlCommand("INSERT INTO `bluray`(`titre`, `duree`, `dateSortie`, `version`, `disponible`) VALUES (?1, ?2, ?3, ?4, 1)", connection);
                command.Parameters.AddWithValue("1", formModel.Titre);
                command.Parameters.AddWithValue("2", formModel.Duree);
                command.Parameters.AddWithValue("3", formModel.DateSortie);
                command.Parameters.AddWithValue("4", formModel.Version);
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
        
        public void SetEmprunteBluray(int id)
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;User Id=root;Password=4VzwvXLf;Database=bluray");
                connection.Open();
                
                MySqlCommand command = new MySqlCommand("UPDATE bluray SET disponible = 0 WHERE id=?id", connection);
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
        
        public void SetRenduBluray(int id)
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;User Id=root;Password=4VzwvXLf;Database=bluray");
                connection.Open();
                
                MySqlCommand command = new MySqlCommand("UPDATE bluray SET disponible = 1 WHERE id=?id", connection);
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

        public void AddBluRayEmprunte(int id, string version, string titre, DateTime dateSortie, string baseUrl)
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;User Id=root;Password=4VzwvXLf;Database=bluray");
                connection.Open();
                MySqlCommand command = new MySqlCommand("INSERT INTO `bluray`(`titre`, `dateSortie`, `duree`, `version`, `disponible`, `IdExterne`, `proprietaire`) VALUES (?1, ?2, ?3, ?4, 0, ?5, (SELECT id FROM sourceEmprunt WHERE baseUrl =?6))", connection);
                command.Parameters.AddWithValue("1", titre);
                command.Parameters.AddWithValue("2", dateSortie);
                command.Parameters.AddWithValue("3", TimeSpan.Parse("00:00:00"));
                command.Parameters.AddWithValue("4", version);
                command.Parameters.AddWithValue("5", id);
                command.Parameters.AddWithValue("6", baseUrl);
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
        
        public void DeleteBluRayEmprunte(int id)
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
        
        public List<string> GetBluRayEmprunteIdAndUrl(int id)
        {
            List<string> result = new List<string>();
            try
            {
                connection = new MySqlConnection("Server=localhost;User Id=root;Password=4VzwvXLf;Database=bluray");
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT `id`, `baseUrl` FROM `sourceEmprunt` WHERE id = (SELECT proprietaire FROM bluray WHERE id=?id)", connection);
                command.Parameters.AddWithValue("id", id);
                MySqlDataReader dr = command.ExecuteReader();
                
                while (dr.Read())
                {
                    result.Add(dr[0].ToString());
                    result.Add(dr[1].ToString());
                }
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return result;
        }
    }
}