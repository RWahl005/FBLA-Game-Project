﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICarMove : MonoBehaviour {

	public int moveSpeed = 30;
	
	// Update is called once per frame
	void Update () {
        if (Camera.main.GetComponent<MainGame>().isPaused)
            return;
        gameObject.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
