using GearHub.Infrastructure.Identity;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GearHub.Infrastructure.Persistence;

public sealed class GearHubDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public GearHubDbContext(
        DbContextOptions<GearHubDbContext> options
    ) : base(options) { }
}