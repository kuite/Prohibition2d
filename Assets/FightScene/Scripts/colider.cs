using UnityEngine;
using System.Collections;

public class colider : MonoBehaviour {
    //public GameObject blood;
    public ParticleSystem blood;
    void Start () {
	
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "fighter" || collision.gameObject.tag == "fighter")
        {
            Instantiate(blood, transform.position, transform.rotation);
			Destroy(gameObject);
        }
		if(collision.gameObject.tag == "Obstacle")
        	Destroy(gameObject);
    }
    void Update () {
	  
	}
}
