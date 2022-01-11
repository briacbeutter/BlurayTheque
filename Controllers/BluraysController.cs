using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Utilities;
using WebApplication.DTOs;
using WebApplication.Models;
using WebApplication.Repositories;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BluraysController
    {
        private readonly ILogger<BluraysController> _logger;

        private readonly BlurayRepository brRepository;

        public BluraysController(ILogger<BluraysController> logger)
        {
            _logger = logger;
            brRepository = new BlurayRepository();
        }

        [HttpGet()]
        public ObjectResult Get()
        {
            List<Bluray> br = brRepository.GetListeBluRay();
            List<InfoBlurayEmpruntViewModel> blurays = br.ConvertAll(InfoBlurayEmpruntViewModel.ToModel);
            return new OkObjectResult(blurays);
        }

        [HttpPost(), Route("{IdBluray}/Emprunt")]
        public ObjectResult EmpruntBluray([FromRoute] IdBlurayRoute route)
        {
            foreach (var bluray in brRepository.GetListeBluRay())
            {
                if (bluray.Id == route.IdBluray)
                {
                    if (bluray.Disponible)
                    {
                        brRepository.SetEmprunteBluray(bluray.Id);
                        return new CreatedResult($"{route.IdBluray}", null);
                    }

                    return new BadRequestObjectResult(
                        "Le Bluray que vous souhaitez emprunter est déjà emprunté par une autre personne");
                }
            }
            return new NotFoundObjectResult($"{route.IdBluray}");
        }

        [HttpDelete(), Route("{IdBluray}")]
        public ObjectResult RenduBluray([FromRoute] IdBlurayRoute route)
        {
            foreach (var bluray in brRepository.GetListeBluRay())
            {
                if (bluray.Id == route.IdBluray)
                {
                    if (!bluray.Disponible)
                    {
                        brRepository.SetRenduBluray(bluray.Id);
                        return new AcceptedResult($"{route.IdBluray}", null);
                    }
                    return new BadRequestObjectResult("Le Bluray que vous souhaitez rendre a déjà été rendu");
                }
            }
            return new NotFoundObjectResult($"{route.IdBluray}");
        }
}
}