using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour 
{
	public GameObject ball;
	Vector3 offset; //The camera position minus the ball position gives the distance between the ball and the camera as a Vector3, this will be our quantifier for that

	void Start () 
	{
		offset = transform.position - ball.transform.position; //my current location (the camera) minus the ball's position is equal to the offset
	}
	
	void Update () 
	{
		transform.position = ball.transform.position + offset; //because we get the offset by subtracting the camera location from the ball location, we can tell the program
															   //where we want the ball by saying the camera location is equal to the ball location plus the offset
	}
}
