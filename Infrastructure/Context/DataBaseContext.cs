using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace Infrastructure.Context;

public partial class DataBaseContext : DbContext
{
    public DataBaseContext ()
    {

    }
    public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)

    {

    }

    public virtual DbSet<Book> Books { get; set; }

  

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BookConfiguration());
       
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
