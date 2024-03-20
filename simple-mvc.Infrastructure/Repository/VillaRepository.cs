using Microsoft.EntityFrameworkCore;
using simple_mvc.Application.Common.Interfaces;
using simple_mvc.Domain.Entities;
using simple_mvc.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace simple_mvc.Infrastructure.Repository
{
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {
        private readonly ApplicationDbContext _db;

        public VillaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
      
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Villa villa)
        {
            _db.Villas.Update(villa);
        }
    }
}
