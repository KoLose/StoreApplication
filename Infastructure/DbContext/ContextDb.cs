using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infastructure.DbContext;

public class ContextDb : Microsoft.EntityFrameworkCore.DbContext
{
    private const string ConnectionString = "Host=localhost;Port=5432;Database=StoreApplication;Username=kolose;Password=123098";

    public ContextDb() : base(new DbContextOptionsBuilder<ContextDb>().UseNpgsql(ConnectionString).Options) { }

    public DbSet<Product> Products { get; set; }
}