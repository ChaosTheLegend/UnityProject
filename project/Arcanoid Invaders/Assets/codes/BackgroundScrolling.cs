using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour {

    public float speed;
    private void FixedUpdate()
    {
        transform.position = new Vector3(0f, transform.position.y - Time.deltaTime * speed, 0f);

         if (transform.position.y <= -9.973107)
         {
             transform.position = new Vector3(0f, 0f, 0f);
         }
    }
}
