﻿using UnityEngine;
using System.Collections;

public class bloodScript : MonoBehaviour {
    private ParticleSystem thisPS;
	// Use this for initialization
	void Start () {
        thisPS = GetComponent<ParticleSystem>();        
    }
	
	// Update is called once per frame
	void Update () {
        if(!thisPS.IsAlive())
            Destroy(gameObject, 0.5f);
    }
}
