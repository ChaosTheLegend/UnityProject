﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyer : MonoBehaviour {

    public GameObject controller;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void  OnTriggerEnter2D(Collider2D other)
	{
		
		Destroy(other.gameObject);
        controller.GetComponent<GM>().LoseLife();

    }
	
}	
