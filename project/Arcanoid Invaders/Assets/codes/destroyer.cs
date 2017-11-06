using System.Collections;
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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "ball" || other.name == "ball(Clone)")
        {
            Destroy(other.gameObject);
            controller.GetComponent<GM>().LoseBall();
        }
        if (other.name == "Bullet1" || other.name == "Bullet1(Clone)")
        {
            Destroy(other.gameObject);
        }
    }
	
}	
