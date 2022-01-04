using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.DTOs;
using WebApplication.Models;
using WebApplication.Repositories;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly BlurayRepository brRepository;
        private readonly PersonneRepository pRepository;
        public List<Personne> acteurs;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            brRepository = new BlurayRepository();
            pRepository = new PersonneRepository();
        }

        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            
            model.Blurays = brRepository.GetListeBluRay();
            
            for(int i=0;i<model.Blurays.Count;i++)
            {
                model.Blurays[i].Realisateur = pRepository.GetRealisateur(model.Blurays[i].Id);
            }
            return View(model);
        }

        public IActionResult SelectedBluRay([FromRoute]int id)
        {
            IndexViewModel model = new IndexViewModel();
            model.Blurays = brRepository.GetListeBluRay();
            model.SelectedBluray = model.Blurays.Find(x => x.Id == id);
            if (model.SelectedBluray != null)
                model.SelectedBluray.Realisateur = pRepository.GetRealisateur(id);
            return View(model);
        }

        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            
            IndexViewModel model = new IndexViewModel();
            //brRepository.DeleteBluRay(id);
            model.Blurays = brRepository.GetListeBluRay();
            return View("Index",model);
        }
        
        public IActionResult AddBluray(AddBlurayViewModel formModel)
        {
            Bluray blurayToAdd = new Bluray
            {
                Id = formModel.Id,
                Titre = formModel.Titre,
                DateSortie = formModel.DateSortie,
                Version = "Courte",
                Duree = formModel.Duree,
                /*Realisateur = new Personne
                {
                    Nom = formModel.Realisateur.ToString().Split(" ")[1],
                    Prenom = formModel.Realisateur.ToString().Split(" ")[0],
                },
                Scenariste = new Personne
                {
                    Nom = formModel.Scenariste.ToString().Split(" ")[1],
                    Prenom = formModel.Scenariste.ToString().Split(" ")[0],
                },*/
            };
            //brRepository.AddBluRay(blurayToAdd);
            IndexViewModel model = new IndexViewModel();
            model.Blurays = brRepository.GetListeBluRay();
            //Response.Redirect("/Home/Index");
            return View("Index",model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public void AddActor(AddBlurayViewModel modelForm)
        {
            acteurs.Add(new Personne
            {
            });
        }

        public IActionResult AddView()
        {
            AddBlurayViewModel model = new AddBlurayViewModel();
            model.Acteurs = pRepository.GetActeurs();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}