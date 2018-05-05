using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turnbine : MonoBehaviour {
    public bool on;
    public float rotationSpeed;
	// Update is called once per frame
	void Update () {
        if(on)
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
	}
}
