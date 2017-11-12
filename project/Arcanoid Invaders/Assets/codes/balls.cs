using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class balls : MonoBehaviour {

	public float force;
	public float state = 0;
	public Transform folowingobj;
	public float rotationangle;

	private Rigidbody2D rb;
	// Use this for initialization
	void Awake() {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (state == 0) {
			rb.isKinematic = true;
		}
        if (state == 1)
        {
            rb.isKinematic = false;
            transform.parent = null;
            rb.AddForce(new Vector3(force, force, 0f));
            state = 2;
        }

		if (state == 2) {
			transform.Rotate (Vector3.forward * Time.deltaTime * rotationangle);
		}
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name != "destroyer" && other.gameObject.name != "Bullet1" && other.gameObject.name != "Bullet1(Clone)") {
			Destroy (other.gameObject, 0.02f);
		}
	}
}
