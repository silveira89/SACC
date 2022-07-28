using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SACC.Models;

namespace SACC.Data {
    public class Contents : IdentityDbContext<User> {
        public Contents(DbContextOptions<Contents> options) : base(options) {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
