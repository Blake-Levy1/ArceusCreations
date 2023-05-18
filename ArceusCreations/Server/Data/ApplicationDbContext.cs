using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Duende.IdentityServer.EntityFramework.Options;
using ArceusCreations.Server.Models;


public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
{
    public ApplicationDbContext(
        DbContextOptions options,
        IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
    {
    }

    public DbSet<Type> Types { get; set; }
    public DbSet<Move> Moves { get; set; }
    public DbSet<Pokemon> Pokemon { get; set; }
}

//dotnet ef dbcontext Scaffold  "name=ConnectionStrings:GSLocal" Microsoft.EntityFrameworkCore.SqlServer -o  Data

