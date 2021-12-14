using System;
using System.Collections.Generic;
using WebApplication.DTOs;

namespace WebApplication.Repositories
{
    public class BlurayRepositories
    {
        private List<Bluray> listBluray = new List<Bluray>();

        /// <summary>
        /// Consctructeur par défaut
        /// </summary>
        public BlurayRepositories()
        {
            listBluray.Add(new Bluray
            {
                Id = 0,
                Titre = "My Little film 1",
                DateSortie = DateTime.Now,
                Version = "Courte",
                Duree = new TimeSpan(1, 06, 30),
                Realisateur = new Personne
                {
                    Nom = "BOUE",
                    Prenom = "Hugo"
                },

                Acteurs = new List<Personne>
                {
                    new Personne
                    {
                        Id = 0,
                        Nom = "Per",
                        Prenom = "Sonne",
                        Nationalite = "Fr",
                        DateNaissance = DateTime.Now,
                        Professions = new List<string> {"Acteur"}
                    }
                }
            });
            listBluray.Add(new Bluray
                {
                    Id = 1,
                    Titre = "My Little film 2",
                    DateSortie = DateTime.Now,
                    Version = "Longue",
                    Duree = new TimeSpan(2, 06, 30),
                    Realisateur = new Personne
                    {
                        Nom = "BEUTTER",
                        Prenom = "Briac"
                    },
                    Acteurs = new List<Personne>
                    {
                        new Personne
                        {
                            Id = 0,
                            Nom = "Per",
                            Prenom = "Sonne",
                            Nationalite = "Fr",
                            DateNaissance = DateTime.Now,
                            Professions = new List<string> {"Acteur"}
                        }
                    }
                }
            );
        }

        public List<Bluray> GetListeBluRay()
        {
            return this.listBluray;
        }

        public void DeleteBluRay(long? id)
        {
            Bluray index = this.listBluray.Find((bl => bl.Id == id));
            this.listBluray.Remove(index);
        }

        public void AddBluRay(Bluray bluray)
        {
            this.listBluray.Add(bluray);
        }
    }
}