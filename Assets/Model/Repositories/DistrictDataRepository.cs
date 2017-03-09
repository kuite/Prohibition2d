using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Model.Buildings;
using Assets.Model.Context;
using Assets.SharedResources.Scripts;

namespace Assets.Model.Repositories
{
    public class DistrictDataRepository : IRepository<DistrictData>
    {
        private SqliteContext _context;

        public DistrictDataRepository(SqliteContext context)
        {
            _context = context;
        }

        public IEnumerable<DistrictData> GetAll()
        {
            return _context.DistrictSettings();
        }

        public DistrictData GetById(int id)
        {
            return _context.Table(new Casino {Id = id});
        }

        public bool Update(DistrictData obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
