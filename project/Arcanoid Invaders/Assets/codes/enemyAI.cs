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
    GameObject newbull;
    public float BulletSpeed;
    public ParticleSystem explode;

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
                newbull = Instantiate(bullet, bulspawn.position, bulspawn.rotation);
                newbull.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -BulletSpeed));
            }
            if (ShootingPattern == 2)
            {
                newbull = Instantiate(bullet, bulspawn.position, bulspawn.rotation);
                newbull.GetComponent<Rigidbody2D>().AddForce(new Vector2(BulletSpeed / 3 * 1, -(BulletSpeed)));
                newbull = Instantiate(bullet, bulspawn.position, bulspawn.rotation);
                newbull.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -BulletSpeed));
                newbull = Instantiate(bullet, bulspawn.position, bulspawn.rotation);
                newbull.GetComponent<Rigidbody2D>().AddForce(new Vector2(-(BulletSpeed / 3 * 1), -(BulletSpeed)));
            }
            if (ShootingPattern == 3)
            {
                newbull = Instantiate(bullet, bulspawn.position, bulspawn.rotation);
                newbull.GetComponent<Rigidbody2D>().AddForce(new Vector2(BulletSpeed / 5 * 2, -(BulletSpeed)));
                newbull = Instantiate(bullet, bulspawn.position, bulspawn.rotation);
                newbull.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -BulletSpeed));
                newbull = Instantiate(bullet, bulspawn.position, bulspawn.rotation);
                newbull.GetComponent<Rigidbody2D>().AddForce(new Vector2(-(BulletSpeed / 5 * 2), -(BulletSpeed)));
                newbull = Instantiate(bullet, bulspawn.position, bulspawn.rotation);
                newbull.GetComponent<Rigidbody2D>().AddForce(new Vector2(BulletSpeed / 5 * 4, -(BulletSpeed)));
                newbull = Instantiate(bullet, bulspawn.position, bulspawn.rotation);
                newbull.GetComponent<Rigidbody2D>().AddForce(new Vector2(-(BulletSpeed / 5 * 4), -(BulletSpeed)));
            }
            if (ShootingPattern == 4)
            {
                newbull = Instantiate(bullet, bulspawn.position, bulspawn.rotation);
                newbull.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -BulletSpeed));
                newbull.GetComponent<Transform>().localScale = new Vector3(2.5f,2.5f,1f);
            }
        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "ball(Clone)" || collision.gameObject.name == "ball") 
        {
            GetComponent<PowerupSpawn>().SpawnP();
            Destroy(Instantiate(explode, transform.position, transform.rotation), 0.2f);
            Destroy(gameObject);
        }
    }
}
