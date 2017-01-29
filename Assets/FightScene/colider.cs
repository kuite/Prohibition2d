using UnityEngine;
using System.Collections;

public class colider : MonoBehaviour {
    //public GameObject blood;
    public ParticleSystem blood;
    void Start () {
	
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "me" || collision.gameObject.tag == "enemy")
        {
            Instantiate(blood, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
    void Update () {
	  
	}
}
