using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour {

    public Transform bulspawn;
    public GameObject bullet;
    public float shootspeed;
    public float maxrange;
    float timeleft;

	// Use this for initialization
	void Start () {
        timeleft = shootspeed + Random.Range(-maxrange, maxrange);
    }
	
	// Update is called once per frame
	void Update () {
        timeleft -= Time.deltaTime;
        if (timeleft <= 0)
        {
            timeleft = shootspeed + Random.Range(-maxrange, maxrange);
            Instantiate(bullet, bulspawn.position, bulspawn.rotation);
        }
	}
}
