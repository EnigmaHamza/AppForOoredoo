using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ooredooApplicationForWeb.Data
{
    public class Categorie
    {
        public int Id { get; set; }

        public string NomCategorie { get; set; }

        // nav
        public List<Observations> observations { get; set; }

        public int? NombreObservations { get; set; }

        public int? NbObservationsPositives{ get; set; }

        public int? NbObservationsNegatives { get; set; }

        public int? NbBonne { get; set; }

        public int? NbMoyenne { get; set; }

        public int? NbIncoherante { get; set; }

        public int? troublé { get; set; }

    }
}
