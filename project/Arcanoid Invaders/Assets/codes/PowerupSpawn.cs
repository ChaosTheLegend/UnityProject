using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawn : MonoBehaviour {

    public GameObject[] powerups;
    int spawnid;
    public void SpawnP()
        
    {
        if (Random.Range(0, 100) <= 25)
        {
            spawnid = (int)Random.Range(0, 4);
            if (spawnid == 4)
            {
                spawnid -= 1;
            }
            Instantiate(powerups[spawnid], transform.position, transform.rotation);
        }
    }
}
