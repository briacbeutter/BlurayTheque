using System;
using WebApplication.DTOs;

namespace WebApplication.Models
{
    public class InfoBlurayEmpruntViewModel
    {
        /// <summary>
        /// Identifiant technique
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// Titre du film 
        /// </summary>
        public string Titre { get; set; }
        
        /// <summary>
        /// Version du film
        /// </summary>
        public string Version { get; set; }
        
        /// <summary>
        /// Date de sortie du film
        /// </summary>
        public DateTime DateSortie { get; set; }
        
        /// <summary>
        /// Disponibilite du film
        /// </summary>
        public Boolean Disponible { get; set; }
        
        public static InfoBlurayEmpruntViewModel ToModel(Bluray dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new InfoBlurayEmpruntViewModel {Id = dto.Id, Titre = dto.Titre, Version = dto.Version, DateSortie = dto.DateSortie, Disponible = dto.Disponible};
        }
        
        public static InfoBlurayEmpruntViewModel ToModel(BlurayApi dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new InfoBlurayEmpruntViewModel {Id = dto.Id, Titre = dto.Titre, Version = dto.Version, DateSortie = dto.DateSortie, Disponible = dto.Disponible};
        }
    }
}