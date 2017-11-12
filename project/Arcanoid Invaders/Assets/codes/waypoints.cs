using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoints : MonoBehaviour {

    public Transform[] pointsB;

    private void Awake()
    {
        pointsB = new Transform[transform.childCount];
        for (int i = 0; i < pointsB.Length; i++)
        {
            pointsB[i] = transform.GetChild(i);
        }
    }
}
