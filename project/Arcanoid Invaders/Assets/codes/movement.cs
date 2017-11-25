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
    public float imunity;
    float imunetimer;
    public static bool hitable = true;
    Animator anim;
    // Use this for initialization
    void imune()
    {
        hitable = false;
        imunetimer = imunity;
        anim.SetBool("hit", true);
    }
    void imunestop()
    {
        hitable = true;
        anim.SetBool("hit", false);
    }

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

	}



    void FixedUpdate () {
        mousex = Input.mousePosition.x;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousex, 35f, 10f));
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7.8f, 7.8f), transform.position.y, transform.position.z);
        if (hitable == false)
        {
            if (imunetimer > 0)
            {
                imunetimer -= Time.deltaTime;
            }
            else
            {
                imunestop();
            }
        }
    }

    public void damage(int damage)
    {
        if (hitable)
        {
            controller.GetComponent<GM>().takedamage(damage);
            imune();
        }
    }
}
