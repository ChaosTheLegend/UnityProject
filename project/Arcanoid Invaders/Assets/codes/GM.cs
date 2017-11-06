using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour {

    public int lives;
    public int balls;
    public GameObject ball;
    public Transform ballspawn;
    internal static object Instance;
    public Transform existedball;
    public Transform plane;
    public Text hptext;
    public Text balltext;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        hptext.text = ""+lives;
        balltext.text = "" +balls;
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
}
