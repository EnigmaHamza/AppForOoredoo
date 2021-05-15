using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ooredooApplicationForWeb.Areas.Identity.Data;

namespace ooredooApplicationForWeb.Data
{
    public class ooredooDbContext : IdentityDbContext<ApplicationUser>
    {
        public ooredooDbContext(DbContextOptions<ooredooDbContext> options)
            : base(options)
        {
        }

        public DbSet<Produits> Produits { get; set; }
        public DbSet<Observations> Observations { get; set; }
        public DbSet<Categorie> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Observations>().HasKey(ob => new { ob.ApplicationUserID, ob.CategorieId , ob.dateObservation });

            builder.Entity<Observations>()
            .HasOne<ApplicationUser>(u => u.user)
            .WithMany(s => s.observations)
            .HasForeignKey(sc => sc.ApplicationUserID);

            builder.Entity<Observations>()
           .HasOne<Categorie>(u => u.categorie)
           .WithMany(s => s.observations)
           .HasForeignKey(sc => sc.CategorieId);


        }
    }
}
