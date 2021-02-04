using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Models
{
    public interface IDatabaseContext
    {
        DbSet<User> Users { get; set; }
        DbSet<VehicleModel> VehicleModels { get; set; }
        DbSet<Vehicle> Vehicles { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}