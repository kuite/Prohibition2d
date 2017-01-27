using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageControll : MonoBehaviour {
	public Image FirstImage;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeToRed(){
		FirstImage.color = Color.red; 
	}
}
