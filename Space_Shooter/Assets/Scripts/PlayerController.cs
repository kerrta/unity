using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public float tilt;

	public Boundary boundary;

	// Update is called once per frame
	void FixedUpdate () {
		// LEFT and RIGHT arrow key input
		float moveHorizontal = Input.GetAxis("Horizontal");
		// UP and DOWN arrow key input
		float moveVertical = Input.GetAxis("Vertical");
		// movement = (movement left or right based on moveHorizontal value) and (movement up or down based on moveVertical value)
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		// Adds movement to ship
		GetComponent<Rigidbody>().velocity = movement * speed;

		GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 0.0f, Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax));

		GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}
}
