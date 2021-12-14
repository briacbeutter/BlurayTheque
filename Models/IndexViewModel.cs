using System.Collections.Generic;
using WebApplication.DTOs;

namespace WebApplication.Models
{
    public class IndexViewModel
    {
        public List<Bluray> Blurays { get; set; }

        public Bluray SelectedBluray { get; set; }
    }
}