using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        private readonly EmpruntRepository eRepository;
        private readonly BlurayApiRepository brApiRepository;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            brRepository = new BlurayRepository();
            pRepository = new PersonneRepository();
            eRepository = new EmpruntRepository();
            brApiRepository = new BlurayApiRepository();
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
            Bluray blurayToAdd = new Bluray
            {
                Titre = formModel.Titre,
                DateSortie = formModel.DateSortie,
                Duree = formModel.Duree,
                Version = formModel.Version
            };
            brRepository.AddBluRay(blurayToAdd);
            int id = brRepository.GetLastBluRay().Id;
            foreach (var acteurs in formModel.ActeursToAdd)
            {
                string[] acteurId = acteurs.Split(",");
                foreach (var acteur in acteurId)
                {
                    pRepository.AddActeursByFilm(id, acteur);
                }
            }
            foreach (var reals in formModel.RealisateursToAdd)
            {
                string[] realId = reals.Split(",");
                foreach (var real in realId)
                {
                    pRepository.AddRealisateurByFilm(id, real);
                }
                
            }
            foreach (var scenas in formModel.ScenaristesToAdd)
            {
                string[] scenaId = scenas.Split(",");
                foreach (var scena in scenaId)
                {
                    pRepository.AddScenaristeByFilm(id, scena);
                }
            }
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
        
        public IActionResult BorrowBluray()
        {
            List<Emprunteur> emprunteurs = eRepository.getBaseUrl();
            BorrowBlurayViewModel brBlurayViewModel = new BorrowBlurayViewModel();
            brBlurayViewModel.Emprunteurs = emprunteurs;
            brBlurayViewModel.Blurays = new List<BlurayApi>();
            return View(brBlurayViewModel);
        }
        
        public IActionResult AddPersonView()
        {
            PersonViewModel model = new PersonViewModel();
            return View("AddPersonView",model);
        }

        public IActionResult HandleSelectBorrowPerson(BorrowBlurayViewModel formModel)
        {
            List<BlurayApi> blurays = brApiRepository.GetBluRays(formModel.SelectEmprunteur);
            BorrowBlurayViewModel borrowBlurayViewModel = new BorrowBlurayViewModel();
            
            borrowBlurayViewModel.Blurays = blurays;
            borrowBlurayViewModel.Emprunteurs = eRepository.getBaseUrl();
            borrowBlurayViewModel.SelectEmprunteur = formModel.SelectEmprunteur;
            return View("BorrowBluray", borrowBlurayViewModel);
        }

        public IActionResult BorrowBlurayWithId(string id, String titre, String version, String dateSortie, String baseUrl)
        {
            brApiRepository.EmprunterBluray(baseUrl, int.Parse(id));
            BorrowBlurayViewModel borrowBlurayViewModel = new BorrowBlurayViewModel();
            borrowBlurayViewModel.Emprunteurs = eRepository.getBaseUrl();
            borrowBlurayViewModel.Blurays = new List<BlurayApi>();
            brRepository.AddBluRayEmprunte(int.Parse(id), version, titre, DateTime.Parse(dateSortie), baseUrl);
            return View("BorrowBluray", borrowBlurayViewModel);
        }
        
        public IActionResult HandleAddPersonView(PersonViewModel formModel)
        {
            Console.WriteLine(formModel.Nom);
            Personne personne = new Personne
            {
                Nom = formModel.Nom,
                Prenom = formModel.Prenom,
                DateNaissance = DateTime.Parse(formModel.DateNaissance),
                Nationalite = formModel.Nationalite
            };
            pRepository.AddPerson(personne);
            PersonViewModel personViewModel = new PersonViewModel();
            return View("AddPersonView",personViewModel);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ReturnBluray(string id)
        {
            List<string> proprietaire = brRepository.GetBluRayEmprunteIdAndUrl(int.Parse(id));
            
            brApiRepository.RendreBluray(proprietaire[1], int.Parse(proprietaire[0]));
            brRepository.DeleteBluRayEmprunte(int.Parse(id));
            
            IndexViewModel model = new IndexViewModel();
            model.Blurays = brRepository.GetListeBluRay();  
            return View("Index",model);
        }
    }
}