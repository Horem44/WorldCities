using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCities.Core.Domain.Entities;
using WorldCities.Infrastructure.ApplicationDatabaseContext;

namespace WorldCities.Infrastructure.Repositories.CitiesRepository
{
    public class CitiesRepository : BaseRepository<City>
    {
        public CitiesRepository(ApplicationDbContext db) : base(db) { }
    }
}
