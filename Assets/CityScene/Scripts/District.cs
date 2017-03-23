using Assets.Model.Buildings;
using Assets.Model.Context;
using UnityEngine;

namespace Assets.CityScene.Scripts
{
    public class District : MonoBehaviour
    {
        public Casino Casino { get; set; }
        public Pub Pub { get; set; }

        public int InstanceId;
        public int SettingsId;
        public Panel Panel;

        
        private DistrictData _data;
        private SqliteContext _context;

        // Use this for initialization
        void Start ()
        {
            //GetSettings();
        }
	
        // Update is called once per frame
        void Update () {
           
        }

        public void OnMouseDown(){
            Panel.UpdateDistrict(this);
            GetSettings();
        }

        private void GetSettings()
        {
            if (DataScript.Instance.DistrictCache.ContainsKey(InstanceId))
            {
                //get data from datascript
                Debug.Log("found existing district");
            }
            else
            {
                _context = DataScript.Instance.Context;
                _data = _context.GetById<DistrictData>(SettingsId);

                Casino = _context.GetById<Casino>(_data.CasinoId);
                Pub = _context.GetById<Pub>(_data.PubId);

                DataScript.Instance.AddDistrict(InstanceId, this);
            }

        }
    }
}
