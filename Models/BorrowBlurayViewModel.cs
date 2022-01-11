using System;
using System.Collections.Generic;
using WebApplication.DTOs;

namespace WebApplication.Models
{
    public class BorrowBlurayViewModel
    {
        
        /// <summary>
        /// Liste des emprunteurs
        /// </summary>
        public List<Emprunteur> Emprunteurs { get; set; }
        
        /// <summary>
        /// Liste des emprunteurs
        /// </summary>
        public string SelectEmprunteur { get; set; }

    }
}