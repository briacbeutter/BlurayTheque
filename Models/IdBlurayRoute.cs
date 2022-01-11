using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class IdBlurayRoute
    {
        /// <summary>
        /// L'Id du BluRay pour la route
        /// </summary>
        [Required]
        public int IdBluray { get; set; }
    }
}