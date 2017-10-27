using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour {

    public int lives;
    public GameObject ball;
    public Transform ballspawn;
    internal static object Instance;
    private Transform existedball;
    public Transform plane;
    public Text hptext;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        hptext.text = ""+lives;
	}
    public void LoseLife()
    {
        lives--;
        existedball = Instantiate(ball, ballspawn.position, ballspawn.rotation).transform;
        existedball.SetParent(plane);
    }
}
