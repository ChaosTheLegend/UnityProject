using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour {

    public Transform[] bulspawn;
    public GameObject[] bullet;
    public float[] shootspeed;
    public float[] maxDelay;
    public int[] ShootingPattern;
    float[] timeleft;
    GameObject newbull;
    public float[] BulletSpeed;
    public int[] damage;
    public Transform[] engines;
    public int totalbroke = 0;
    bool dead = false;
    public GameObject Explode;
    public ParticleSystem Shoot;
    // Use this for initialization
    void Start()
    {
        timeleft = new float[bulspawn.Length];
        for (int i = 0; i < bulspawn.Length; i++)
        {
            timeleft[i] = shootspeed[i] + Random.Range(-maxDelay[i], maxDelay[i]);
        }

        timeleft[0] = shootspeed[0];
        timeleft[1] = shootspeed[1]/2;

    }

    // Update is called once per frame
    void Update()
    { 
        for (int i = 0;i<engines.Length; i++)
        {
            if (engines[i].GetComponent<GetHit>().brocken)
            {
                totalbroke++;
            }
        }
        if(totalbroke == engines.Length && dead == false)
        {
            transform.position = GetComponent<BossMovement>().Path.GetComponent<waypoints>().pointsB[0].position;
            GetComponent<BossMovement>().speed = 0f;
            GetComponent<ParticleControll>().InvokeRepeating("death",0f,0.05f);
            dead = true;
            Invoke("Explosion", 2f);
        }
        totalbroke = 0;

        for (int i = 0; i < bulspawn.Length; i++)
        {
            if (GetComponent<BossMovement>().Path == GetComponent<BossMovement>().MainPath)
            {
                timeleft[i] -= Time.deltaTime;
            }

            if (timeleft[i] <= 0 && dead == false)
            {
                timeleft[i] = shootspeed[i] + Random.Range(-maxDelay[i], maxDelay[i]);
                if (ShootingPattern[i] == 1)
                {
                    newbull = Instantiate(bullet[i], bulspawn[i].position, bulspawn[i].rotation);
                    newbull.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -BulletSpeed[i]));
                    newbull.GetComponent<bullet>().basedamage = damage[i];
                }
                if (ShootingPattern[i] == 2)
                {
                    newbull = Instantiate(bullet[i], bulspawn[i].position, bulspawn[i].rotation);
                    newbull.GetComponent<Rigidbody2D>().AddForce(new Vector2(BulletSpeed[i] / 3 * 1, -(BulletSpeed[i])));
                    newbull.GetComponent<bullet>().basedamage = damage[i];

                    newbull = Instantiate(bullet[i], bulspawn[i].position, bulspawn[i].rotation);
                    newbull.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -BulletSpeed[i]));
                    newbull.GetComponent<bullet>().basedamage = damage[i];

                    newbull = Instantiate(bullet[i], bulspawn[i].position, bulspawn[i].rotation);
                    newbull.GetComponent<Rigidbody2D>().AddForce(new Vector2(-(BulletSpeed[i] / 3 * 1), -(BulletSpeed[i])));
                    newbull.GetComponent<bullet>().basedamage = damage[i];
                }
                if (ShootingPattern[i] == 3)
                {
                    newbull = Instantiate(bullet[i], bulspawn[i].position, bulspawn[i].rotation);
                    newbull.GetComponent<Rigidbody2D>().AddForce(new Vector2(BulletSpeed[i] / 5 * 2, -(BulletSpeed[i])));
                    newbull.GetComponent<bullet>().basedamage = damage[i];

                    newbull = Instantiate(bullet[i], bulspawn[i].position, bulspawn[i].rotation);
                    newbull.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -BulletSpeed[i]));
                    newbull.GetComponent<bullet>().basedamage = damage[i];

                    newbull = Instantiate(bullet[i], bulspawn[i].position, bulspawn[i].rotation);
                    newbull.GetComponent<Rigidbody2D>().AddForce(new Vector2(-(BulletSpeed[i] / 5 * 2), -(BulletSpeed[i])));
                    newbull.GetComponent<bullet>().basedamage = damage[i];

                    newbull = Instantiate(bullet[i], bulspawn[i].position, bulspawn[i].rotation);
                    newbull.GetComponent<Rigidbody2D>().AddForce(new Vector2(BulletSpeed[i] / 5 * 4, -(BulletSpeed[i])));
                    newbull.GetComponent<bullet>().basedamage = damage[i];

                    newbull = Instantiate(bullet[i], bulspawn[i].position, bulspawn[i].rotation);
                    newbull.GetComponent<Rigidbody2D>().AddForce(new Vector2(-(BulletSpeed[i] / 5 * 4), -(BulletSpeed[i])));
                    newbull.GetComponent<bullet>().basedamage = damage[i];
                }
                if (ShootingPattern[i] == 4)
                {
                    newbull = Instantiate(bullet[i], bulspawn[i].position, bulspawn[i].rotation);
                    newbull.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -BulletSpeed[i]));
                    newbull.GetComponent<Transform>().localScale = new Vector3(2.5f, 2.5f, 1f);
                    newbull.GetComponent<bullet>().basedamage = damage[i];
                }
                ParticleSystem shooting = Instantiate(Shoot, bulspawn[i].position, bulspawn[i].rotation);
                shooting.transform.parent = transform;
                Destroy(shooting,1.1f);
            }
        }
    }
    void Explosion()
    {
        Destroy(Instantiate(Explode, transform.position, transform.rotation).gameObject, 1.1f);
        Destroy(gameObject);
    }
}
