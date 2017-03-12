using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Model.Buildings;
using Assets.Model.Context;

namespace Assets.Model.Repositories
{
    public class PubRepository : IRepository<Pub>
    {
        public PubRepository(SqliteContext context)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pub> GetAll()
        {
            throw new NotImplementedException();
        }

        public Pub GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Pub obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
