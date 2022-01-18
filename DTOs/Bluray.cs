using System;
using System.Collections.Generic;

namespace WebApplication.DTOs
{
    /// <summary>
    /// Dto d'un Disque Blu-Ray
    /// </summary>
    public class Bluray
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
        public List<Personne> Scenariste  { get; set; }

        /// <summary>
        /// Le réalisateur du film
        /// </summary>
        public Personne Realisateur { get; set; }

        /// <summary>
        /// Les acteurs du film
        /// </summary>
        public List<Personne> Acteurs { get; set; }

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
        
        /// <summary>
        /// Affiche du film
        /// </summary>
        public string Image { get; set; }
        
        /// <summary>
        /// Disponibilite du film
        /// </summary>
        public Boolean Disponible { get; set; }
        
        public Boolean Emprunt { get; set; }
    }
}