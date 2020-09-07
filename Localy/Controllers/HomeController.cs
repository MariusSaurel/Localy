using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using SiteLocaly.Filters;
using SiteLocaly.ViewModels;

namespace SiteLocaly.Controllers
{
    public class HomeController : Controller
    {
        //Contexte de la base de données
        LocalyEntities Context = new LocalyEntities();

        public int FirstPosition = 100;
        public ActionResult Acceuil()
        {
            //Coordonnées par défaut
            ViewBag.defaultN = "43.610769";
            ViewBag.defaultE = "3.876716";

            var coo = new List<decimal>();
            coo.Add(Convert.ToDecimal(43.610769));
            coo.Add(Convert.ToDecimal(3.876716));

            RechercheViewModel vm = new RechercheViewModel("", 500, coo);

            return View(vm);
        }

        public ActionResult Recherche(string recherche, int rayonMax, decimal lat, decimal lon)
        {
            var adresseRecherche = new List<decimal>();
            adresseRecherche.Add(lat);
            adresseRecherche.Add(lon);

            RechercheViewModel vm = new RechercheViewModel(recherche, rayonMax, adresseRecherche);

            List<Magasin> mags = Context.Magasin.OrderBy(m => m.id).ToList();
            List<MagasinViewModel> magsZone = vm.getMagasinsDansZone(mags);

            //Donne tous les magasins qui contienne la recherche dans leur nom ou qui contiennent au moins un article dont le nom contient la recherche
            magsZone = magsZone.Where(m => (m.libelle.ToUpper().Contains(recherche.ToUpper())) || (m.Articles.Where(a => a.libelle.ToUpper().Contains(recherche.ToUpper())).Count() > 0)).ToList();


            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(magsZone);


            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}