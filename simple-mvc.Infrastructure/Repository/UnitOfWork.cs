using simple_mvc.Application.Common.Interfaces;
using simple_mvc.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_mvc.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IVillaRepository villaRepository { get; private set; }

        public IVillaNumberRepository villaNumberRepository { get; private set; }

        public IAmenityRepository amenityRepository { get; private set; }
        public void Save()
        {
            _db.SaveChanges();
        }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            villaRepository = new VillaRepository(_db);
            villaNumberRepository = new VillaNumberRepository(_db);
            amenityRepository = new AmenityRepository(_db);
        }
    }
}
