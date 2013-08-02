using UnityEngine;
using System.Collections;

public class MoveTank : MonoBehaviour
{

	public float rotationSpeed = 2f;
	public float rate = 0.5f;
	private float last;
	private Quaternion currentRotation;
	public float acc;
	public float maxSpeed;
	private float currentSpeed;
	
	void Start ()
	{
	//	transform.position = new Vector3 (0, 0.8f, 0);
		currentRotation = Quaternion.identity;
	}
	
	void Update ()
	{
		currentSpeed += acc * Time.deltaTime;
		if(currentSpeed > maxSpeed){
			currentSpeed = maxSpeed;
		}
		rigidbody.velocity = transform.forward * currentSpeed;
		transform.rotation = Quaternion.RotateTowards(transform.rotation, currentRotation, Time.deltaTime * 10f);
//		Debug.Log(rigidbody.velocity);
		//transform.position += new Vector3(30f*Time.deltaTime, 0, 0);
		if (Input.GetKey ("a")) {
			transform.position -= new Vector3 (0.2f, 0, 0);
			transform.Rotate (0, 0, 2);
		}
		if (Input.GetKey ("d")) {
			transform.position += new Vector3 (0.2f, 0, 0);
			transform.Rotate (0, 0, -2);
		}		
		transform.rotation = Quaternion.Slerp (transform.rotation, currentRotation, Time.deltaTime * rotationSpeed);
	}

	void OnCollisionEnter (Collision collision)
	{
		if (collision.relativeVelocity.magnitude > 0) {
			currentSpeed = 1f;
		}
	}

	public void Turn (bool isToRight)
	{
		currentRotation = Quaternion.Euler (0f, currentRotation.eulerAngles.y + (isToRight ? 90f : -90f), 0f);	
		
	}
}
