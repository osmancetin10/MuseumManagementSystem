using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MuseumManagementSystem.Areas.Identity.Data;
using MuseumManagementSystem.Data;

[assembly: HostingStartup(typeof(MuseumManagementSystem.Areas.Identity.IdentityHostingStartup))]
namespace MuseumManagementSystem.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
           
        }
    }
}