using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMobileContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMobileContext>>()))
        {
            
            if (context.Mobile.Any())
            {
                return;   // DB has been seeded
            }
            context.Mobile.AddRange(
                new Mobile
                {
                    Name = "A79",
                    MobileImage = "download (1).JPG",
                    Color = "Blue",
                    Description = " abcdef",
                    Price = 7.99M

                },
                new Mobile
                {
                    Name = "A54 ",
                    MobileImage = "download.JPG",
                    Color = "Red",
                    Description = "abcdef",
                    Price = 8.99M
                },
                new Mobile
                {
                    Name = " A72",
                    MobileImage = "download (2).JPG",
                    Color = "yellow",
                    Description = "abcdef",
                    Price = 19.99M
                }
                // new Mobile
                // {
                //     Name = "Rio Bravo",
                //     MobileImage = "dss",
                //     Color = "Pink",
                //     Description = "Western",
                //     Price = 3.99M
                // }
            );
            context.SaveChanges();
        }
    }
}