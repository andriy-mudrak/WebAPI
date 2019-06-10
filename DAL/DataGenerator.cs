using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace DAL
{
    public class DataGenerator
    {
        public static void Initialize( IServiceProvider serviceProvider )
        {
            using ( var context = new MyDBContext(
                serviceProvider.GetRequiredService<DbContextOptions<MyDBContext>>() ) )
            {
                if ( context.Books.Any() )
                {
                    return;  
                }

                context.Books.AddRange(
                    new Book
                    {
                        Id = 1,
                        Title = "The Lord of the Rings",
                        Author = "J. R. R. Tolkien",
                    },
                    new Book
                    {
                        Id = 2,
                        Title = "Arthur and the Invisibles",
                        Author = "Luc Besson",
                    },
                     new Book
                     {
                         Id = 3,
                         Title = "The Witcher",
                         Author = " Andrzej Sapkowski",
                     } );

                context.SaveChanges();
            }
        }
    }
}
