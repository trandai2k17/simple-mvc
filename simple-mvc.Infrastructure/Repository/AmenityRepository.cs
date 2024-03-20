using simple_mvc.Application.Common.Interfaces;
using simple_mvc.Domain.Entities;
using simple_mvc.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_mvc.Infrastructure.Repository
{
    public class AmenityRepository : Repository<Amenity>, IAmenityRepository
    {
        private readonly ApplicationDbContext _db;
        public AmenityRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public  void Update(Amenity amenity)
        {
            _db.Amenities.Update(amenity);
        }

    }
}
