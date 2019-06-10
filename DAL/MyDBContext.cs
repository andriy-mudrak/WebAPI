using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public partial class MyDBContext: DbContext
    {
        public MyDBContext( DbContextOptions options )
            : base( options )
        {
        }

        public virtual DbSet<Book> Books { get; set; }
    }
}
