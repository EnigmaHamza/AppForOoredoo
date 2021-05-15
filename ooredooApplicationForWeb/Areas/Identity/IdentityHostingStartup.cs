using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ooredooApplicationForWeb.Areas.Identity.Data;
using ooredooApplicationForWeb.Data;

[assembly: HostingStartup(typeof(ooredooApplicationForWeb.Areas.Identity.IdentityHostingStartup))]
namespace ooredooApplicationForWeb.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
              //  services.AddDbContext<ooredooDbContext>(options =>
              //      options.UseSqlServer(
                 //       context.Configuration.GetConnectionString("ooredooDbContextConnection")));

                
            });
        }
    }
}