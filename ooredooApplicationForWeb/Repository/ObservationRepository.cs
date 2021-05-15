using ooredooApplicationForWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ooredooApplicationForWeb.Repository
{
    public class ObservationRepository : IObservationRepository
    {
        private readonly ooredooDbContext _context;

        public ObservationRepository(ooredooDbContext context)
        {
            _context = context;
        }
        public int NbBonneObservation(int id)  // nb bonne
        {


            var nb = (from obj in _context.Observations
                      where obj.rating.Equals("Bonne") && obj.CategorieId.Equals(id)
                      select obj).Count();
                    

            return nb;
        }

        public IQueryable<Observations> observations(int? id)
        {
            var obs = (from obj in _context.Observations
                       where obj.CategorieId == id
                       select obj
                        );
            return obs;
        }
    }
}
