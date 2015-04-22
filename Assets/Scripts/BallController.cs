using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour 
{

	public float moveSpeed;
	public float jumpSpeed;
	bool isGrounded = true;

	void Update () 
	{
		float x = Input.GetAxis ("Horizontal")* moveSpeed * Time.deltaTime;
		float z = Input.GetAxis ("Vertical")* moveSpeed * Time.deltaTime;

		Vector3 force = new Vector3 (x , 0f , z);
			
		// if the jump button is pressed and isGrounded is true, jump once and change isGrounded to false
		if (Input.GetButton ("Jump")&& isGrounded) 
		{
			force.y = jumpSpeed;
			isGrounded = false;
		}

		rigidbody.AddForce (force);
	}

	// if the tag of the collision object is JumpableSurface, reset the isGrounded condition to true
	void OnCollisionEnter (Collision collision)
	{
		if (collision.collider.CompareTag ("JumpableSurface")) 
		{
			isGrounded = true;
		}
	}

	// if the tag of the trigger object the script holder enters is CoinTag, make it inactive and increase the score	
	void OnTriggerEnter (Collider other) 
		{
		if (other.CompareTag("CoinTag")) 
		{
			other.gameObject.SetActive (false);
			ScoreTracker.Instance.AddScore(100);
		}
	}
}
