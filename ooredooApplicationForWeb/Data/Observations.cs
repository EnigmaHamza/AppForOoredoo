using ooredooApplicationForWeb.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ooredooApplicationForWeb.Data
{
    public enum Rating
    {
        Bonne,
        Moyenne,
        troublé,
        incohérente
    }
    public enum TypeSuivie 
    {
        Disponibilite,
        Recommendation
    }
    public class Observations
    {
        public string ApplicationUserID { get; set; }
        public ApplicationUser user { get; set; }

        public int CategorieId { get; set; }
        public Categorie categorie { get; set; }

        public DateTime dateObservation { get; set; }

        public TypeSuivie? typeSuivie { get; set; }

        public Rating rating { get; set; }

        public string Nom { get; set; }

        public string? text { get; set; }

        

        // navigation 


        

    }
}
