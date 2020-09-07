using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Localy.Models
{
    public class RechercheModel 
    {
        string recherche { get; set; }
        int rayonMax { get; set; }
        List<decimal> adresseRecherche { get; set; }
        public List<Magasin> MagasinsDansZone { get; set; }
        public List<Magasin> MagasinsProches { get; set; }

        public RechercheModel(string recherche, int rayonMax, List<decimal> adresseRecherche)
        {
            this.recherche = recherche;
            this.rayonMax = rayonMax;
            this.adresseRecherche = adresseRecherche;
        }

        public List<MagasinViewModel> getMagasinsDansZone(List<Magasin> mags)
        {
            var magsZone = new List<MagasinViewModel>();

            var geoloc = new GeoCoordinate((double)adresseRecherche[0], (double)adresseRecherche[1]);

            //Recherche des magasin dans la zone
            foreach (Magasin mag in mags)
            {
                double lat = Decimal.ToDouble(mag.Adresse.latitude);
                double lon = Decimal.ToDouble(mag.Adresse.longitude);

                var pointMagasin = new GeoCoordinate(lat, lon);
                var distance = geoloc.GetDistanceTo(pointMagasin) / 1000;
                if (distance <= rayonMax)
                {
                    var magZone = new MagasinViewModel()
                    {
                        id = mag.id,
                        libelle = mag.nom,
                        latitude = mag.Adresse.latitude,
                        longitude = mag.Adresse.longitude,
                        Articles = new List<ArticleViewModel>()
                    };

                    foreach (var q in mag.Quantite)
                    {
                        var art = new ArticleViewModel();
                        art.libelle = q.Article.nom;

                        magZone.Articles.Add(art);
                    }

                    magsZone.Add(magZone);
                }
            }

            return magsZone;
        }

        public List<Magasin> getMagasinsProches()
        {
            List<Magasin> mags = new List<Magasin>();

            //Recherche des magasins proches

            return mags;
        }

        public List<Article> getMagasinArticle(int id)
        {
            List<Article> arts = new List<Article>();

            return arts;
        }
    }

}
}