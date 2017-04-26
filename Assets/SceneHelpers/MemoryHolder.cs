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
        public List<int> UserDistricts { get; set; }
		public Dictionary<int, District> CaschedDistricts { get; set; }
		public List<int> NoOnesDisctricts { get; set; }
		public int AttackedDistrict;
		public string Winner;

        public Dictionary<int, SoldierStats> UserSoldiers { get; set; }
		public Dictionary<int, SoldierStats> CompSoldiers { get; set; }
		public Dictionary<int, SoldierStats> UserFightingSoldiers { get; set; }
		public Dictionary<int, SoldierStats> EnemyFightingSoldiers { get; set; }
		public Dictionary<int, SoldierStats> NeutralSoldiers { get; set; }
		public Dictionary<int, SoldierStats> NeutralFightingSoldiers { get; set; }
		public Dictionary<int, SoldierStats> AvailableSoldiers { get; set; }
		public List<int> Map { get; set; }

        public SqliteContext Context { get; private set; }

		public PlayerResources playerResources;
		public PlayerResources computerResources;

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
			playerResources = new PlayerResources ();
			playerResources.Money = 100;
			playerResources.Alkohol = 0;
			computerResources = new PlayerResources ();
			computerResources.Money = 100;
			computerResources.Alkohol = 0;

            Context = new SqliteContext(Application.dataPath + "\\SharedResources\\data.s3db");
            CompDistricts = new List<int>();
            UserDistricts = new List<int>();
			NoOnesDisctricts = new List<int>();

			CaschedDistricts = new Dictionary<int, District>();
            UserSoldiers = new Dictionary<int, SoldierStats>();
            CompSoldiers = new Dictionary<int, SoldierStats>();
			UserFightingSoldiers = new Dictionary<int, SoldierStats>();
			EnemyFightingSoldiers = new Dictionary<int, SoldierStats>();
			NeutralFightingSoldiers = new Dictionary<int, SoldierStats>();
			NeutralSoldiers = new Dictionary<int, SoldierStats>();
			AvailableSoldiers = new Dictionary<int, SoldierStats>();
            var soldiers = Context.Table<SoldierStats>().ToList();
			var enemySoldiers = Context.Table<SoldierStats>().ToList();
			var neutralSoldiers = Context.Table<SoldierStats>().ToList();

            int soldId = 0;
			soldiers.ForEach(s => AvailableSoldiers.Add(soldId++, s));
			soldId = 0;
			enemySoldiers.ForEach(s => CompSoldiers.Add(soldId++, s));
			soldId = 0;
			neutralSoldiers.ForEach(s => NeutralSoldiers.Add(soldId++, s));

            var enemyDistricts = Context.Table<EnemyDistrict>().ToList();
            var userDistricts = Context.Table<UserDistrict>().ToList();

            foreach (EnemyDistrict district in enemyDistricts)
            {
                CompDistricts.Add(district.DistrictId);
            }
            foreach (UserDistrict district in userDistricts)
            {
                UserDistricts.Add(district.DistrictId);
            }
        }
    }
}
