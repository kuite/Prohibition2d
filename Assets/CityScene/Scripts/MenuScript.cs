﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript2 : MonoBehaviour {

	public void ChangeScene(string SceneName){
		SceneManager.LoadScene (SceneName);
	}
}
