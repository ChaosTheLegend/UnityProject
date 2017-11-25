using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHit : MonoBehaviour {

    public GameObject boss;
    public bool brocken = false; 

    private void OnTriggerEnter2D(Collider2D other)
    {
            if (other.tag == "Ball" && brocken == false)
            {
               boss.GetComponent<ParticleControll>().Hit(transform);
               brocken = true;
            }
    }
}
