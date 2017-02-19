using Assets.CityScene.Scripts;
using Assets.Model.Buildings;
using Assets.Model.Context;
using UnityEngine;

namespace Assets.SharedResources.Scripts
{
    public class District : MonoBehaviour {

        public int SettingsId { get; set; }
        public int Population;
        public Panel Panel;

        // Use this for initialization
        void Start () {
            //Population = 100000; //here we need pull data from db
            //Panel =  GameObject.FindGameObjectWithTag("panel_Tag");
        }
	
        // Update is called once per frame
        void Update () {
		    
        }

        public void OnMouseDown(){
            Debug.Log(Application.persistentDataPath);
            Panel.WorkingDistrict = this;
        }

        public void PlusOne()
        {
            Population++;
            Debug.Log(Application.persistentDataPath);
        }

    }
}
