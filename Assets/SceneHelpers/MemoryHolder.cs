﻿using System.Collections.Generic;
using System.Linq;
using Assets.CityScene.Scripts;
using Assets.Model.Context;
using Assets.Model.PlayableEntities;
using UnityEngine;

namespace Assets.SceneHelpers
{
    public class MemoryHolder : MonoBehaviour
    {
        private static MemoryHolder _instance;

        public List<int> UserDistricts { get; set; }
        public List<int> CompDistricts { get; set; }
        public Dictionary<int, District> CaschedDistricts { get; set; }
        public Dictionary<int, SoldierStats> UserSoldiers { get; set; }
        public Dictionary<int, SoldierStats> CompSoldiers { get; set; }

        public SqliteContext Context { get; private set; }

        public static MemoryHolder GetInstance()
        {
//            if (_instance == null)
//            {
//                _instance = new MemoryHolder();
//            }

			return _instance;
		}

        // Use this for initialization
        private void Start()
        {
            if (_instance != null)
            {
                Destroy(this.gameObject);
                return;
            }
            Context = new SqliteContext(Application.dataPath + "\\SharedResources\\data.s3db");
            UserDistricts = new List<int>();
            CompDistricts = new List<int>();
            CaschedDistricts = new Dictionary<int, District>();
            UserSoldiers = new Dictionary<int, SoldierStats>();
            CompSoldiers = new Dictionary<int, SoldierStats>();

            var soldiers = Context.Table<SoldierStats>().ToList();

            int soldId = 0;
            soldiers.ForEach(s => UserSoldiers.Add(soldId++, s));

            _instance = this;
            GameObject.DontDestroyOnLoad(this.gameObject);
        }

        // Update is called once per frame
        private void Update()
        {

        }
    }
}
