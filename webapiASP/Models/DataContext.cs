using Microsoft.EntityFrameworkCore;

namespace webapiASP.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options){}
    public DbSet<Prices> Prices => Set<Prices>();
    public DbSet<RegistrationProgram> RegistrationProgram => Set<RegistrationProgram>();
    public DbSet<Persons> Users => Set<Persons>();
}