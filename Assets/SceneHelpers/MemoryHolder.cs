﻿using System.Collections.Generic;
using System.Linq;
using Assets.CityScene.Scripts;
using Assets.Model.Context;
using Assets.Model.PlayableEntities;
using UnityEngine;

namespace Assets.SceneHelpers
{
    public class MemoryHolder
    {
        private static MemoryHolder _instance;

        public List<int> UserDistricts { get; set; }
        public List<int> CompDistricts { get; set; }
        public Dictionary<int, District> CaschedDistricts { get; set; }
		public Dictionary<int, SoldierStats> AvailableSoldiers { get; set; }
        public Dictionary<int, SoldierStats> UserSoldiers { get; set; }
		public Dictionary<int, SoldierStats> CompSoldiers { get; set; }
		public Dictionary<int, SoldierStats> UserFightingSoldiers { get; set; }
		public Dictionary<int, SoldierStats> EnemyFightingSoldiers { get; set; }

        public SqliteContext Context { get; private set; }

        public static MemoryHolder GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MemoryHolder();
            }

			return _instance;
		}

        public MemoryHolder()
        {
            Context = new SqliteContext(Application.dataPath + "\\SharedResources\\data.s3db");
            UserDistricts = new List<int>();
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
			/*soldiers.ForEach(s => UserSoldiers.Add(soldId++, s));
			soldId = 0;
			enemySoldiers.ForEach(s => CompSoldiers.Add(soldId++, s));*/
        }
    }
}
