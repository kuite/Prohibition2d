using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using Assets.Model.Buildings;
using Assets.Model.Context;

namespace Assets.Model.Repositories
{
    public class CasinoRepository : IRepository<Casino>
    {
        private SqliteContext _context;
        private IDictionary<int, Casino> _casinos;

        public CasinoRepository(SqliteContext context)
        {
            _context = context;
        }

        public IEnumerable<Casino> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Casino GetById(int id)
        {
//            if (_casinos.ContainsKey(id))
//            {
//                Casino cas;
//                _casinos.TryGetValue(id, out cas);
//                return cas;
//            }
            return _context.GetCasinoById(id);
        }

        public bool Update(Casino obj)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}