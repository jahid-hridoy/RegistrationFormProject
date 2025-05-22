using Microsoft.EntityFrameworkCore;
using RegistrationFormProject.Models;

namespace RegistrationFormProject.Data;

public class RegFormDbContext: DbContext
{
    public RegFormDbContext(DbContextOptions<RegFormDbContext> options) : base(options)
    {
    }
    public DbSet<RegForm> RegForms { get; set; }
}
