using Assets.Model.Buildings;
using Assets.Model.Context;
using UnityEngine;

namespace Assets.CityScene.Scripts
{
    public class District : MonoBehaviour
    {
        public Casino Casino { get; set; }
        public Pub Pub { get; set; }
        public Distillery Distillery { get; set; }
        public LocalBussines LocalBussines { get; set; }
        public NightClub NightClub { get; set; }

        public int SettingsId;
        public Panel Panel;

        private SqliteContext _context;

        public District(SqliteContext context)
        {
            _context = context;
            //Data = districtRepository.GetById(SettingsId);
            Casino = _context.GetById<Casino>(5);
        }


        // Use this for initialization
        void Start ()
        {
            GetSettings();
        }
	
        // Update is called once per frame
        void Update () {
           
        }

        public void OnMouseDown(){
            Debug.Log(Application.persistentDataPath);
            Panel.UpdateDistrict(this);
        }

        private void GetSettings()
        {
            DistrictData settings = _context.GetById<DistrictData>(SettingsId);
            var x = 6;
        }
    }
}
