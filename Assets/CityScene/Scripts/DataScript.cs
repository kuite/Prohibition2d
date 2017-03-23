using System.Collections.Generic;
using System.Linq;
using Assets.Model.Buildings;
using Assets.Model.Context;
using Assets.Model.PlayableEntities;
using UnityEngine;

namespace Assets.CityScene.Scripts
{
    public class DataScript : MonoBehaviour
    {
        public static DataScript Instance;

        public Dictionary<int, District> DistrictCache { get; private set; }
        public Dictionary<int, SoldierStats> UserSoldiers { get; set; }
        public Dictionary<int, SoldierStats> CompSoldiers { get; set; }

        public SqliteContext Context { get; private set; }

        // Use this for initialization
        void Start()
        {
            if (Instance != null)
            {		
                Destroy(this.gameObject);
                return;
            }
            Context = new SqliteContext(Application.dataPath + "\\SharedResources\\data.s3db");
            DistrictCache = new Dictionary<int, District>();
            UserSoldiers = new Dictionary<int, SoldierStats>();
            CompSoldiers = new Dictionary<int, SoldierStats>();

            var soldiers = Context.Table<SoldierStats>().ToList();

            int soldId = 0;
            soldiers.ForEach(s => UserSoldiers.Add(soldId++, s));

            Instance = this;
            GameObject.DontDestroyOnLoad(this.gameObject);
        }

        public void AddDistrict(int key, District value)
        {
            DistrictCache.Add(key, value);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
