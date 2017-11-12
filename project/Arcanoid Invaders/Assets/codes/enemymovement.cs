using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymovement : MonoBehaviour {

    public float speed;

    private Transform target;
    private int waypointind = 0;
    public Transform Path;
	// Use this for initialization
	void Start () {
        target = Path.GetComponent<waypoints>().pointsB[0];
        transform.position = Path.GetComponent<waypoints>().pointsB[0].position;
    }
	
	void Update () {
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);
        if (Vector2.Distance(transform.position,target.position) <= 0.1f)
        {
            if (waypointind+1 == Path.GetComponent<waypoints>().pointsB.Length)
            {
                waypointind = 0;
                transform.position = Path.GetComponent<waypoints>().pointsB[0].position;
            }
            else
            {
                waypointind++;
            }
            target = Path.GetComponent<waypoints>().pointsB[waypointind];
        }
    }
}
