using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public float rotationangle;

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationangle);
    }
}
