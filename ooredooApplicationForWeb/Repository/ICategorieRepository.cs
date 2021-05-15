using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ooredooApplicationForWeb.Repository
{
   public  interface ICategorieRepository
    {
        public int NombreObservation(int c_id);

        public int NbRatingPositive(int c_id);

        public int NbRatingNegative(int c_id);

        public int NbRatingBonne(int c_id);

        public int NbRatingMoyenne(int c_id);

        public int NbRatingTrouble(int c_id);

        public int NbRatingincoherent(int c_id);
    }
}
