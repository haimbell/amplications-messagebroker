using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Service1.Infrastructure.Models;

namespace Service1.Infrastructure;

public class Service1DbContext : IdentityDbContext<IdentityUser>
{
    public Service1DbContext(DbContextOptions<Service1DbContext> options)
        : base(options) { }

    public DbSet<Me> Us { get; set; }
}
