﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Localy.Models
{
    public class Acheteur
    {

        public int id { get; set; }
        public Utilisateur utilisateur { get; set; }

    }
}