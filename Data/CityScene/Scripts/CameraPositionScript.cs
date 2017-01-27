using UnityEngine;
using System.Collections;
public class CameraPositionScript : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {

	}
	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -5);
	}
}