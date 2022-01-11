using System;
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
            foreach(var var in model.Blurays)
            {
                var.Realisateur = pRepository.GetRealisateur(var.Id);
                var.Scenariste = pRepository.GetScenariste(var.Id);
                var.Acteurs = pRepository.GetActeursByFilm(var.Id);
            }
            return View(model);
        }

        public IActionResult SelectedBluRay([FromRoute]int id)
        {
            IndexViewModel model = new IndexViewModel();
            model.Blurays = brRepository.GetListeBluRay();
            model.SelectedBluray = model.Blurays.Find(x => x.Id == id);
            if (model.SelectedBluray != null)
            {
                model.SelectedBluray.Realisateur = pRepository.GetRealisateur(id);
                model.SelectedBluray.Scenariste = pRepository.GetScenariste(id);
                model.SelectedBluray.Acteurs = pRepository.GetActeursByFilm(id);
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            IndexViewModel model = new IndexViewModel();
            brRepository.DeleteBluRay(id);
            model.Blurays = brRepository.GetListeBluRay();
            return View("Index",model);
        }
        
        public IActionResult AddBluray(AddBlurayViewModel formModel)
        {
            Console.WriteLine(formModel.ActeursToAdd[0]+"," + formModel.ActeursToAdd[1]);
            Console.WriteLine(formModel.RealisateursToAdd[0]+"," + formModel.RealisateursToAdd[1]);
            Console.WriteLine(formModel.ScenaristesToAdd[0]+"," + formModel.ScenaristesToAdd[1]);

            Bluray blurayToAdd = new Bluray
            {
                Id = formModel.Id,
                Titre = formModel.Titre,
                DateSortie = formModel.DateSortie,
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
            brRepository.AddBluRay(blurayToAdd);
            IndexViewModel model = new IndexViewModel();
            model.Blurays = brRepository.GetListeBluRay();
            return View("Index",model);
        }

        public IActionResult Privacy()
        {
            return View();
        }



        public IActionResult AddView()
        {
            AddBlurayViewModel model = new AddBlurayViewModel();
            model.Acteurs = pRepository.GetPersonnes();
            model.Realisateurs = model.Acteurs;
            model.Scenaristes = model.Acteurs;
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}