namespace WebApplication.DTOs
{
    public class Emprunteur
    {
        /// <summary>
        /// Identifiant technique
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Nom de l'emprunteur
        /// </summary>
        public string Nom { get; set; }
        
        /// <summary>
        /// Url d'accès
        /// </summary>
        public string BaseUrl { get; set; }
    }
}