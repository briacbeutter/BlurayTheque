using System;
using System.Collections.Generic;
using System.ComponentModel;
using WebApplication.DTOs;

namespace WebApplication.Models

{
    public class AddBlurayViewModel
    {

        /// <summary>
        /// Identifiant technique
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Titre du film contenu sur le Blu-Ray
        /// </summary>
        public string Titre { get; set; }

        /// <summary>
        /// Le scénariste du film
        /// </summary>
        public List<Personne> Scenaristes  { get; set; }
        
        /// <summary>
        /// Le scénariste du film
        /// </summary>
        public List<Personne> ScenaristesToAdd  { get; set; }

        /// <summary>
        /// Le réalisateur du film
        /// </summary>
        public List<Personne> Realisateurs { get; set; }
        
        /// <summary>
        /// Le réalisateur du film
        /// </summary>
        public List<Personne> RealisateursToAdd { get; set; }

        /// <summary>
        /// Les acteurs du film
        /// </summary>
        public List<Personne> Acteurs { get; set; }
        
        /// <summary>
        /// Les acteurs du film
        /// </summary>
        public List<int> ActeursToAdd { get; set; }

        /// <summary>
        /// Durée du film
        /// </summary>
        public TimeSpan Duree { get; set; }    

        /// <summary>
        /// Date de sortie du film
        /// </summary>
        public DateTime DateSortie { get; set; }

        /// <summary>
        /// Langues disponibles sur le BR
        /// </summary>
        public List<string> Langues { get; set; }

        /// <summary>
        /// Sous-titres disponible sur le BR
        /// </summary>
        public List<string> SsTitres { get; set; }

        /// <summary>
        /// Version du film sur le BR
        /// </summary>
        public string Version { get; set; }
        
    }
}