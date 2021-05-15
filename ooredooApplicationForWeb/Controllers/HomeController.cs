using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ooredooApplicationForWeb.Models;
using ooredooApplicationForWeb.Repository;

namespace ooredooApplicationForWeb.Controllers
{
   [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IObservationRepository _observationRepository;

        public HomeController(ILogger<HomeController> logger, IObservationRepository observationRepository)
        {
            _logger = logger;
            _observationRepository = observationRepository;
        }


        public IActionResult Index()
        {
            
                int nb = _observationRepository.NbBonneObservation(2);

            ViewBag.nbr = nb;


            return View();
        }
        public IActionResult tableau()
        {
            return View();
        }
        // index disp sim prepl
        public IActionResult Disp_offre_prep()
        {
            return View("/Views/Home/offre_prepayes/index.cshtml");
        }
        // index recommandation offre prepayes
        public IActionResult Reco_offre_prep()
        {
            return View("/Views/Home/offre_prepayes/index_reco.cshtml");
        }

        // dash disp diagrammes en batons
        public IActionResult Disponibilite()
        {
            return View("/Views/Home/offre_prepayes/Disponibilite.cshtml");
        }
        // dash disp carte de dispo disp_carte_sim
        public IActionResult disp_carte_sim()
        {
            return View("/Views/Home/offre_prepayes/disp_carte_sim.cshtml");
        }
        // dash recommandation offres prépayées 
        public IActionResult reco_indiv()
        {
            return View("/Views/Home/offre_prepayes/reco_individuelle.cshtml");
        }
        // dash recommandation comparaison 
        public IActionResult reco_compar()
        {
            return View("/Views/Home/offre_prepayes/reco_comparaison.cshtml");
        }
        // dash recommandation carte 
        public IActionResult reco_carte()
        {
            return View("/Views/Home/offre_prepayes/reco_carte.cshtml");
        }
        

        // offres 3g 
        // index des offres 3g 
       
        public IActionResult index_reco_offre_3g()
        {
            return View("/Views/Home/offre3g/_index_reco.cshtml");
        }
        // dash performances des offres
        public IActionResult perfo_offre()
        {
            return View("/Views/Home/offre3g/_performance_offre.cshtml");
        }
        // _recommandation des o
      public IActionResult suivi_offre_3g()
        {
            return View("/Views/Home/offre3g/_suivie_offre_3g.cshtml");
        }

        public IActionResult testview()
        {
            return View("/Views/Administration/TestView1.cshtml");
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
