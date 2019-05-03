using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookWorm.Models
{
    public class BookWormContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Documents> Documents { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Upload> Uploads { get; set; }
        public DbSet<Format> Formats { get; set; }

        public BookWormContext()
            : base("name = BookWorm", throwIfV1Schema: false)
        {
        }
        public static BookWormContext Create()
        {
            return new BookWormContext();
        }
    }
}