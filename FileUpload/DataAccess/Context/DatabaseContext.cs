using FileUpload.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace FileUpload.API.DataAccess.Context;
public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<ImageUpload> ImageUploads { get; set; }
}

