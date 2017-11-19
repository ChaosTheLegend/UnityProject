using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour {

    public Transform bulspawn;
    public GameObject bullet;
    public float shootspeed;
    public float maxrange;
    public int ShootingPattern;
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
            if (ShootingPattern == 1)
            {
                Instantiate(bullet, bulspawn.position, bulspawn.rotation);
            }
            if (ShootingPattern == 2)
            {
                Instantiate(bullet, bulspawn.position, bulspawn.rotation);
                Instantiate(bullet, bulspawn.position, bulspawn.rotation);
                Instantiate(bullet, bulspawn.position, bulspawn.rotation);
            }
        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "ball(Clone)" || collision.gameObject.name == "ball") 
        {  
        Destroy(gameObject);
        }
    }
}
