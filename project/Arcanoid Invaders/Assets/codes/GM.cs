﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour {

    public int lives;
    public int balls;
    public GameObject ball;
    public GameObject Spawner;
    public Transform ballspawn;
    internal static object Instance;
    public Transform existedball;
    public Transform plane;
    public Text hptext;
    public Text balltext;
    public RectTransform Wavetextpos;
    public Text Wavetext;
    float Wavedisspeed;
    bool display;
    int wave;
    float timer;
    // Use this for initialization
    void Start() {
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        hptext.text = ""+lives;
        balltext.text = "" +balls;
        
        timer += Time.deltaTime;
        if (display == true)
        {
            Wavedisplay();
        }
    }
    public void LoseBall()
    {
        balls--;
        existedball = Instantiate(ball, ballspawn.position, ballspawn.rotation).transform;
        existedball.SetParent(plane);
    }
    public void takedamage()
    { 
        lives--;
    }
    public void shoot()
    {
        if (existedball.GetComponent<balls>().state == 0)
        {
            existedball.GetComponent<balls>().state = 1;
        }
    }
    void Wavedisplay()
    {
        if (wave == 0)
        {
            Wavetext.text = "Start!";
        }
        else
        {
            Wavetext.text = "Wave " + wave;
        }
		if (Wavetextpos.GetComponent<RectTransform>().anchoredPosition.y < 350f)
        {
            Wavedisspeed = Mathf.Pow(timer,2);
			Wavetextpos.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, Wavetextpos.GetComponent<RectTransform>().anchoredPosition.y + Wavedisspeed);
        }
		if (Wavetextpos.GetComponent<RectTransform>().anchoredPosition.y > 350f)
        {
            display = false;
            Wavedisspeed = 0f;
			Wavetextpos.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, -350f);
            Spawner.GetComponent<Spawning>().spawn = true;
			Wavetextpos.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, -350f);
        }
    }

    public void Wavedisstart(int curwave)
    {
        Wavedisspeed = 0f;
		Wavetextpos.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, -350f);
        timer = -2.75f;
        wave = curwave;
        display = true;
    }
}
