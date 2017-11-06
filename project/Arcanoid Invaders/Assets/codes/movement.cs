using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class movement : MonoBehaviour {

    public Camera main;
	private float mousex;
    Rigidbody2D rb;
    public GameObject controller;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}



    void FixedUpdate () {
        mousex = Input.mousePosition.x;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousex, 25f, 10f));
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7.8f, 7.8f), transform.position.y, transform.position.z);
    }

    public void damage()
    {
        controller.GetComponent<GM>().takedamage();
    }
}
