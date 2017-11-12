using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour {

    public GameObject[] enemies;
    public Transform[] pathes;
    int[,] spawncount;
    int wave = 1;
    float timer;
    public float delay;
    int[] enemiesonscene;
    int totalenemies;
    int totalspawn;

    // Use this for initialization
    void Start()
    {
        enemiesonscene = new int[enemies.Length];
        spawncount = new int[100, enemies.Length];
        InvokeRepeating("spawnenemy", delay, delay);
        spawncount[1, 0] = 10;
        spawncount[2, 0] = 5;
    }
	// Update is called once per frame
	void FixedUpdate () {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = delay;
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
    }

    void spawnenemy()
    {
        //print("spawning...");
        if (totalenemies == 0 && totalspawn == 0)
        {
            wave++;
        }
        else
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (spawncount[wave,i] > 0)
                {
                    spawncount[wave,i]--;
                    Instantiate(enemies[i], transform.position, transform.rotation).GetComponent<enemymovement>().Path = pathes[i] ;
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
