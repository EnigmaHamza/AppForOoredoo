using ooredooApplicationForWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ooredooApplicationForWeb.Repository
{
    public class CategorieRepository : ICategorieRepository
    {

        private readonly ooredooDbContext _context;
        public CategorieRepository(ooredooDbContext context)
        {
            _context = context;
        }
        

        public int NombreObservation(int c_id)
        {
            var nb = (
                        from obj in _context.Observations
                        where obj.CategorieId.Equals(c_id)
                        select obj
                     )
                     .Count();

            return nb;
        }
        public int NbRatingPositive(int c_id)
        {
            var nb = (
                      from obj in _context.Observations
                      where ( (obj.CategorieId.Equals(c_id) ) &&  (  (obj.rating==Rating.Bonne) || ( obj.rating == Rating.Moyenne ) ) )
                      select obj
                   )
                   .Count();

           
                
            return nb;
        }

        public int NbRatingNegative(int c_id)
        {
            var nb = (
                       from obj in _context.Observations
                       where ( (obj.CategorieId.Equals(c_id)) && ( (obj.rating == Rating.incohérente) || (obj.rating == Rating.troublé) ))
                       select obj
                    )
                    .Count();

            return nb;
        }

        public int NbRatingBonne(int c_id)
        {
            var nb = (
                    from obj in _context.Observations
                    where (  ( obj.CategorieId.Equals(c_id)) && (obj.rating == Rating.Bonne) )
                    select obj
                 )
                 .Count();

            return nb;
        }

        public int NbRatingMoyenne(int c_id)
        {
            var nb = (
                    from obj in _context.Observations
                    where ((obj.CategorieId.Equals(c_id)) && (obj.rating == Rating.Moyenne))
                    select obj
                 )
                 .Count();

            return nb;
        }
        public int NbRatingTrouble(int c_id)
        {
            var nb = (
                    from obj in _context.Observations
                    where    ((obj.CategorieId.Equals(c_id)) && (obj.rating == Rating.troublé))
                    select obj
                 )
                 .Count();

            return nb;
        }
        public int NbRatingincoherent(int c_id)
        {
            var nb = (
                   from obj in _context.Observations
                   where ((obj.CategorieId.Equals(c_id)) && (obj.rating == Rating.incohérente))
                   select obj
                )
                .Count();

            return nb;
        }

     

      

     
    }
}
