using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ooredooApplicationForWeb.Data
{
    public class Produits
    {
        [Key]
        public int Id { get; set; }
        public string Categorie { get; set; }
        public string nom { get; set; }


        // navigations

        public List<Observations> Observations { get; set; }
    }
}
