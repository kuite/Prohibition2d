using System.Collections.Generic;
using System.Linq;
using Assets.CityScene.Scripts;
using Assets.Model.Context;
using Assets.Model.GameSettings;
using Assets.Model.PlayableEntities;
using UnityEngine;

namespace Assets.SceneHelpers
{
    public class MemoryHolder
    {
        private static MemoryHolder _instance;

        public EnemyUser EnemyUser { get; set; }
        public User User { get; set; }

        public List<int> CompDistricts { get; set; }
        public Dictionary<int, District> CaschedDistricts { get; set; }
        public Dictionary<int, SoldierStats> UserSoldiers { get; set; }
		public Dictionary<int, SoldierStats> CompSoldiers { get; set; }
		public Dictionary<int, SoldierStats> UserFightingSoldiers { get; set; }
		public Dictionary<int, SoldierStats> EnemyFightingSoldiers { get; set; }
		public Dictionary<int, SoldierStats> AvailableSoldiers { get; set; }

        public SqliteContext Context { get; private set; }

        public static MemoryHolder GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MemoryHolder();
            }

			return _instance;
		}

        private MemoryHolder()
        {
            Context = new SqliteContext(Application.dataPath + "\\SharedResources\\data.s3db");
            CompDistricts = new List<int>();
            CaschedDistricts = new Dictionary<int, District>();
            UserSoldiers = new Dictionary<int, SoldierStats>();
            CompSoldiers = new Dictionary<int, SoldierStats>();
			UserFightingSoldiers = new Dictionary<int, SoldierStats>();
			EnemyFightingSoldiers = new Dictionary<int, SoldierStats>();
			AvailableSoldiers = new Dictionary<int, SoldierStats>();
            var soldiers = Context.Table<SoldierStats>().ToList();
			var enemySoldiers = Context.Table<SoldierStats>().ToList();

            int soldId = 0;
			soldiers.ForEach(s => AvailableSoldiers.Add(soldId++, s));
			soldId = 0;
			enemySoldiers.ForEach(s => CompSoldiers.Add(soldId++, s));


            CompDistricts.Add(1);
//            User = new User
//            {
//                Districts = new List<int>(),
//                Soldiers = new Dictionary<int, SoldierStats>(),
//                FightingSoldiers = new Dictionary<int, SoldierStats>()
//            };
//
//            EnemyUser = new EnemyUser
//            {
//                Districts = new List<int>(),
//                Soldiers = new Dictionary<int, SoldierStats>(),
//                FightingSoldiers = new Dictionary<int, SoldierStats>()
//            };
        }
    }
}
