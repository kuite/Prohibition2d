using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Model.Buildings;
using Assets.Model.Context;
using Assets.SharedResources.Scripts;

namespace Assets.Model.Repositories
{
    public class DistrictRepository : IRepository<DistrictSettings>
    {
        private SqliteContext _context;

        public DistrictRepository(SqliteContext context)
        {
            _context = context;
        }

        public IEnumerable<DistrictSettings> GetAll()
        {
            return _context.DistrictSettings();
        }

        public DistrictSettings GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(DistrictSettings obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
