using ooredooApplicationForWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ooredooApplicationForWeb.ViewModels
{
    public class CategorieObservations
    {
        public int Id { get; set; }

        public string NomCategorie { get; set; }

        // nav
        public List<Observations> observations { get; set; }

        public int? NombreObservations { get; set; }

        public int? NbObservationsPositives { get; set; }

        public int? NbObservationsNegatives { get; set; }
    }
}
