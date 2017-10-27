using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

	public float speed;
	public float maxtilt;
	float moveHorizontal;
	// Use this for initialization
	void Start () {
		
	}

	void FixedUpdate () {
		moveHorizontal = Input.GetAxis ("Horizontal");
		transform.position = new Vector3 (Mathf.Clamp (transform.position.x + moveHorizontal * speed, -7.7f, 7.7f), -4.4f, 0f);
		transform.rotation = Quaternion.Euler(0, 0, maxtilt * -moveHorizontal);
	
	}
}
