using Microsoft.EntityFrameworkCore;

namespace XTradesRecrutationTask.Models;

public class XTradesDBContext : DbContext
{
    protected readonly IConfiguration _configuration;

    public XTradesDBContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("PostgresConnection"));
    }
}