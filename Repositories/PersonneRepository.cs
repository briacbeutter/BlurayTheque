using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WebApplication.DTOs;

namespace WebApplication.Repositories
{
    public class PersonneRepository
    {

        public Personne GetRealisateur(int idFilm)
        {
            MySqlConnection connection = null;
            Personne realisateur = null;

            try
            {
                connection = new MySqlConnection("Server=localhost;User Id=root;Password=4VzwvXLf;Database=bluray");
                connection.Open();

                MySqlCommand command =
                    new MySqlCommand(
                        "SELECT p.* FROM personne p INNER JOIN bluRayRealisateur br on br.idRealisateur=p.id WHERE br.idBluray=?identifiant",
                        connection);
                command.Parameters.AddWithValue("identifiant", idFilm);
                MySqlDataReader dr = command.ExecuteReader();

                // Output rows
                if (dr.Read())
                {
                    realisateur = new Personne
                    {
                        Id = long.Parse(dr[0].ToString()),
                        Nom = dr[1].ToString(),
                        Prenom = dr[2].ToString(),
                        DateNaissance = (DateTime) dr[3],
                        Nationalite = dr[4].ToString()
                    };
                }
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return realisateur;
        }

        public List<Personne> GetScenariste(int idFilm)
        {
            MySqlConnection connection = null;
            List<Personne> scenariste = new List<Personne>();

            try
            {
                connection = new MySqlConnection("Server=localhost;User Id=root;Password=4VzwvXLf;Database=bluray");
                connection.Open();

                MySqlCommand command =
                    new MySqlCommand(
                        "SELECT p.* FROM personne p INNER JOIN bluRayScenariste bs on bs.idScenariste=p.id WHERE bs.idBluray=?identifiant",
                        connection);
                command.Parameters.AddWithValue("identifiant", idFilm);
                MySqlDataReader dr = command.ExecuteReader();

                // Output rows
                while (dr.Read())
                {
                    scenariste.Add(new Personne
                    {
                        Id = long.Parse(dr[0].ToString()),
                        Nom = dr[1].ToString(),
                        Prenom = dr[2].ToString(),
                        DateNaissance = (DateTime) dr[3],
                        Nationalite = dr[4].ToString()
                    });
                }
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return scenariste;
        }

        public List<Personne> GetActeursByFilm(int idFilm)
        {
            MySqlConnection connection = null;
            List<Personne> acteurs = new List<Personne>();

            try
            {
                connection = new MySqlConnection("Server=localhost;User Id=root;Password=4VzwvXLf;Database=bluray");
                connection.Open();

                MySqlCommand command =
                    new MySqlCommand(
                        "SELECT p.* FROM personne p INNER JOIN bluRayActeurs ba on ba.idActeur=p.id WHERE ba.idBluray=?identifiant",
                        connection);
                command.Parameters.AddWithValue("identifiant", idFilm);
                MySqlDataReader dr = command.ExecuteReader();

                // Output rows
                while (dr.Read())
                {
                    acteurs.Add(new Personne
                    {
                        Id = long.Parse(dr[0].ToString()),
                        Nom = dr[1].ToString(),
                        Prenom = dr[2].ToString(),
                        DateNaissance = (DateTime) dr[3],
                        Nationalite = dr[4].ToString()
                    });
                }
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return acteurs;
        }
        
        public void AddActeursByFilm(int idFilm, int acteur)
        {
            MySqlConnection connection = null;

            try
            {
                connection = new MySqlConnection("Server=localhost;User Id=root;Password=4VzwvXLf;Database=bluray");
                connection.Open();
                
                MySqlCommand command =
                        new MySqlCommand(
                            "INSERT INTO `bluRayActeurs`(`idBluray`, `idActeur`) VALUES (?1, ?2)", connection);
                    command.Parameters.AddWithValue("1", idFilm);
                    command.Parameters.AddWithValue("2", acteur);
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

        public void AddScenaristeByFilm(int idFilm, int scenariste)
        {
            MySqlConnection connection = null;

            try
            {
                connection = new MySqlConnection("Server=localhost;User Id=root;Password=4VzwvXLf;Database=bluray");
                connection.Open();
                
                MySqlCommand command =
                        new MySqlCommand(
                            "INSERT INTO `bluRayScenariste`(`idBluray`, `idScenariste`) VALUES (?1, ?2)", connection);
                    command.Parameters.AddWithValue("1", idFilm);
                    command.Parameters.AddWithValue("2", scenariste);
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

        public void AddRealisateurByFilm(int idFilm, int realisateur)
        {
            MySqlConnection connection = null;

            try
            {
                connection = new MySqlConnection("Server=localhost;User Id=root;Password=4VzwvXLf;Database=bluray");
                connection.Open();
                
                MySqlCommand command =
                        new MySqlCommand(
                            "INSERT INTO `bluRayRealisateur`(`idBluray`, `idRealisateur`) VALUES (?1, ?2)", connection);
                    command.Parameters.AddWithValue("1", idFilm);
                    command.Parameters.AddWithValue("2", realisateur);
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

        public List<Personne> GetPersonnes()
        {
        MySqlConnection connection = null;
        List<Personne> acteurs = new List<Personne>();

        try
        {
            connection = new MySqlConnection("Server=localhost;User Id=root;Password=4VzwvXLf;Database=bluray");
            connection.Open();

            MySqlCommand command =
                new MySqlCommand(
                    "SELECT p.* FROM personne p",
                    connection);
            MySqlDataReader dr = command.ExecuteReader();

            // Output rows
            while (dr.Read())
            {
                acteurs.Add(new Personne
                {
                    Id = long.Parse(dr[0].ToString()),
                    Nom = dr[1].ToString(),
                    Prenom = dr[2].ToString(),
                    DateNaissance = (DateTime) dr[3],
                    Nationalite = dr[4].ToString()
                });
            }
        }
        finally
        {
            if (connection != null)
            {
                connection.Close();
            }
        }

        return acteurs;
        }
    }
}