using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public Text countText;

	public float speed;
	private int cnt;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		cnt = 0;
		SetCountText();
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(movement * speed);
	}

	void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("Pick Up"))
        {
            other.gameObject.SetActive (false);
        	cnt++;
        	SetCountText();
        }
    }

    void SetCountText()
    {
    	countText.text = "Score: " + cnt.ToString() + "/12";	
    }
}
