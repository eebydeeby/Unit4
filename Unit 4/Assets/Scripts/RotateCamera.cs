using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
	public float rotationSpeed; // Variable for speed of rotation
	
	// Rotates the camera around the platform when A or D is pressed
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
		transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
