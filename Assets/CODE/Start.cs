﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
	}
}
