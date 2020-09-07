using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Localy.Models
{
    public class Utilisateur
    {

        public int id { get; set; }
        public string mail { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string motDePasse { get; set; }

    }
}