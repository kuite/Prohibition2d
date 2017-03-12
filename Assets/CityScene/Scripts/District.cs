﻿using Assets.Model.Buildings;
using Assets.Model.Context;
using UnityEngine;

namespace Assets.CityScene.Scripts
{
    public class District : MonoBehaviour
    {
        public DistrictData Data { get; set; }
        public Casino Casino { get; set; }

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
            //Panel =  GameObject.FindGameObjectWithTag("panel_Tag");
        }
	
        // Update is called once per frame
        void Update () {
           
        }

        public void OnMouseDown(){
            Debug.Log(Application.persistentDataPath);
            //Panel.WorkingDistrict = this;
            Panel.UpdateDistrict(this);
        }

        private void GetSettings()
        {
            
        }
    }
}
