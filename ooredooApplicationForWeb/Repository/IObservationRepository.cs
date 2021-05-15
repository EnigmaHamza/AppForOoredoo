using ooredooApplicationForWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ooredooApplicationForWeb.Repository
{
    public interface IObservationRepository
    {
        public int NbBonneObservation(int id);
        public IQueryable<Observations> observations(int? id);
    }
}
