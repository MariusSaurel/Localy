using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Localy.Dao;

namespace Localy.Models
{
    public class Magasin
    {

        public int id { get; set; }
        public string intitule { get; set; }
        public Adresse adresse { get; set; }
        public Version vendeur { get; set; }

        public List<decimal> getCoordonnees()
        {
            var lst = new List<decimal>();

            Magasin Mag = new MagasinDao.

            if (Adresse.latitude != null && Adresse.longitude != null)
            {
                lst.Add(this.Adresse.latitude);
                lst.Add(this.Adresse.longitude);
            }
            else
            {
                //Erreur une des deux vals est null

            }

            return lst;
        }
    }
}