using Assets.CityScene.Scripts.SubPanels;
using Assets.Model.Buildings;
using Assets.Model.Context;
using Assets.SceneHelpers;
using UnityEngine;

namespace Assets.CityScene.Scripts
{
    public class District : MonoBehaviour
    {
        public Casino Casino { get; set; }
        public Pub Pub { get; set; }
        public NightClub NightClub { get; set; }
        public Distillery Distillery { get; set; }
        public LocalBussines LocalBussines { get; set; }

        public int InstanceId;
        public int SettingsId;
        public Panel Panel;

        private DistrictData _data;
        private SqliteContext _context;

        public void OnMouseDown()
        {
            if (MemoryHolder.GetInstance().CompDistricts.Contains(InstanceId))
            {
                Panel.UpdateDistrict(this);
                Panel.SelectPanel(Panel.EnemyDistrictPanel);
            }
            if (MemoryHolder.GetInstance().UserDistricts.Contains(InstanceId))
            {
                SetData();
                if (Panel.SelectedPanel is EnemyDistrictPanel ||
                    Panel.SelectedPanel == null)
                {
                    Panel.SelectPanel(Panel.PubPanel);
                }
                Panel.UpdateDistrict(this);
            }
        }

        private void Start ()
        {
            _context = MemoryHolder.GetInstance().Context;
            _data = _context.GetById<DistrictData>(SettingsId);

            Casino = _context.GetById<Casino>(_data.CasinoId);
            Pub = _context.GetById<Pub>(_data.PubId);
            NightClub = _context.GetById<NightClub>(_data.NightClubId);
            LocalBussines = _context.GetById<LocalBussines>(_data.LocalBusinessId);
            Distillery = _context.GetById<Distillery>(_data.DistilleryId);

            MemoryHolder.GetInstance().CaschedDistricts.Add(InstanceId, this);
        }

        private void Update () {
           
        }

        private void SetData()
        {
			if (MemoryHolder.GetInstance().CaschedDistricts.ContainsKey(InstanceId))
            {
                District caschedDist;
                if (MemoryHolder.GetInstance().CaschedDistricts.TryGetValue(InstanceId, out caschedDist))
                {
                    Casino = caschedDist.Casino;
                    Pub = caschedDist.Pub;
                    NightClub = caschedDist.NightClub;
                    LocalBussines = caschedDist.LocalBussines;
                    Distillery = caschedDist.Distillery;
                }
            }
        }
    }
}
