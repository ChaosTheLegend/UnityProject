﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class movement : MonoBehaviour {

	public float speed;
	public float maxtilt;
	float moveHorizontal;

    // Use this for initialization
    void Start () {
		
	}

    public void buttonreleased()
    {
        moveHorizontal = 0;
    }

        void FixedUpdate () {
        moveHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");

        transform.position = new Vector3(Mathf.Clamp(transform.position.x + moveHorizontal * speed, -7.7f, 7.7f), -4.4f, 0f);
        transform.rotation = Quaternion.Euler(0, 0, maxtilt * -moveHorizontal * speed);
    }

}
