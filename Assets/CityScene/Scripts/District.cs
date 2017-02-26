using Assets.Model.Buildings;
using Assets.Model.Context;
using Assets.Model.Repositories;
using UnityEngine;

namespace Assets.CityScene.Scripts
{
    public class District : MonoBehaviour
    {
        public DistrictSettings Settings { get; set; }
        public Casino Casino { get; set; }

        public int SettingsId;
        public Panel Panel;

        private SqliteContext _context;

        public District(SqliteContext context)
        {
            _context = context;
            var districtRepository = new DistrictRepository(_context);
            var casinoRepository = new CasinoRepository(_cotenxt);
            Settings = districtRepository.GetById(SettingsId);


        }


        // Use this for initialization
        void Start ()
        {
            GetSettings();
            //Panel =  GameObject.FindGameObjectWithTag("panel_Tag");
        }
	
        // Update is called once per frame
        void Update () {
           
        }

        public void OnMouseDown(){
            Debug.Log(Application.persistentDataPath);
            Panel.WorkingDistrict = this;
        }

        private void GetSettings()
        {
            
        }
    }
}
