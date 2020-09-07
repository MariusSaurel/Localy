using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Localy.Models
{
    public class Adresse
    {

        public int id { get; set; }
        public string adresse { get; set; }
        public string codePostal { get; set; }
        public string complement { get; set; }
        public string intitule { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }

    }
}