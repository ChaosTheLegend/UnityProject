using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupAI : MonoBehaviour {

    public int id;
    public float speed;
    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector3(0f,-speed,0f));
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "plane")
        {
            other.GetComponent<movement>().controller.GetComponent<PowerupControll>().Powerup(id);
            Destroy(gameObject);
        }
    }
}
