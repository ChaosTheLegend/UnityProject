using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour {

    public GameObject controller;
    public GameObject[] enemies;
    public Transform[] pathes;
    public GameObject[] Bosses;
    public Transform BossEnterPath;
    public Transform[] BossMainPath;
    int[,] spawncount;
    public int wave = 0;
    float timer;
    public bool spawn;
    public float[] delay;
    int[] enemiesonscene;
    int totalenemies;
    int totalspawn;
    int bosscount = 0;
    GameObject newboss;

    // Use this for initialization
    void Start()
    {
        enemiesonscene = new int[enemies.Length];
        spawncount = new int[100, enemies.Length];
        
        spawncount[1, 0] = 5;
        spawncount[2, 0] = 10;
        spawncount[3, 1] = 19;
        spawncount[4, 0] = 5;
        spawncount[4, 1] = 10;
        spawncount[5, 1] = 5;
        spawncount[5, 2] = 10;
        spawncount[6, 0] = 10;
        spawncount[6, 2] = 10;
        spawncount[8, 1] = 10;
        spawncount[8, 2] = 10;
        spawncount[9, 0] = 15;
        spawncount[9, 1] = 12;
        spawncount[10, 0] = 15;
        spawncount[10, 1] = 7;
        spawncount[10, 2] = 7;
        spawncount[11, 0] = 8;
        spawncount[11, 2] = 15;
        spawncount[12, 1] = 15;
        spawncount[12, 0] = 5;
        spawncount[12, 2] = 15;
        spawncount[13, 1] = 10;
        spawncount[13, 2] = 15;
        spawncount[14, 0] = 15;
        spawncount[14, 1] = 10;
        spawncount[14, 2] = 15;



        prespawn();
    }
	// Update is called once per frame
	void FixedUpdate () {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = delay[wave];
            if (spawn)
            {
                spawnenemy();
            }
        }
        for (int i = 0; i < enemies.Length; i++)
        {
            enemiesonscene[i] = 0;
        }
        totalspawn = 0;
        totalenemies = 0;
        countenemies();
        
    }

    private void Update()
    {
        countenemies();
        if (wave == 16)
        {
            controller.GetComponent<MenuControll>().Invoke("Win",1f);
            Destroy(gameObject);
        }
    }
    void prespawn()
    {
        spawn = false;
        controller.GetComponent<GM>().Wavedisstart(wave);
    }

        void spawnenemy()
    {
        //print("spawning...");
        
            if (((wave == 7 && bosscount == 0) || (wave == 15 && bosscount == 1)) && totalenemies == 0)
            {
                newboss = Instantiate(Bosses[bosscount], transform.position, transform.rotation);
                newboss.GetComponent<BossMovement>().MainPath = BossMainPath[bosscount];
                newboss.GetComponent<BossMovement>().EnterPath = BossEnterPath;

                bosscount++;
                countenemies();
            }
        if (totalenemies == 0 && totalspawn == 0)
        {
            wave++;
            prespawn();
        }
        else
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (spawncount[wave, i] > 0)
                {
                    spawncount[wave, i]--;
                    Instantiate(enemies[i], transform.position, transform.rotation).GetComponent<enemymovement>().Path = pathes[i];
                    /*print("enemy spawned");
                    print("total enemies:" + (totalenemies+1));*/
                }
            }
        }

    }


    void countenemies()
    {
        GameObject[] allenemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in allenemies)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemy == enemies[i])
                {
                    enemiesonscene[i]++;
                }
            }
        }
        totalenemies = allenemies.Length;
        for (int i = 0; i < enemies.Length; i++)
        {
            totalspawn += spawncount[wave,i];
        }
    }

}
