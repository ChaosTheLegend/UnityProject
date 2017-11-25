using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    Rigidbody2D rb;
    public int basedamage = 1;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "plane")
        {
            if (GetComponent<Transform>().localScale.x < 2)
            {
                other.GetComponent<movement>().damage(basedamage);
            }
            else if (GetComponent<Transform>().localScale.x < 3)
            {
                other.GetComponent<movement>().damage(2*basedamage);
            }
            else if (GetComponent<Transform>().localScale.x < 4)
            {
                other.GetComponent<movement>().damage(3*basedamage);
            }
            else if (GetComponent<Transform>().localScale.x < 5)
            {
                other.GetComponent<movement>().damage(4*basedamage);
            }
            Destroy(gameObject);
        }
        if (other.name == "Shield")
        {
            Destroy(gameObject);
        }
    }
}
