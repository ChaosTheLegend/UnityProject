using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balls : MonoBehaviour {

	public float force;
	private float state;
	public Transform folowingobj;
	public float rotationangle;

	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		state = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (state == 0) {
			rb.isKinematic = true;

			if (Input.GetKeyUp (KeyCode.Space)) {
				state = 1;
			}
		}
		if (state == 1) {
			rb.isKinematic = false;
			transform.parent = null;
			rb.AddForce (new Vector3 (force, force, 0f));
			state = 2;
		}
		if (state == 2) {
			transform.Rotate (Vector3.forward * Time.deltaTime * rotationangle);
		}
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name != "destroyer") {
			Destroy (other.gameObject, 0.02f);
		}
	}
}
