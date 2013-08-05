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
	private Vector3 pos;
	
	void Start ()
	{
		transform.position = new Vector3 (0, 0.5f, 0);
		currentRotation = Quaternion.identity;
	}

	void Update ()
	{
		if (transform.forward == new Vector3 (1, 0, 0)) {
			pos = new Vector3 (0, 0, -0.35f);	
		}
		if (transform.forward == new Vector3 (0, 0, 1)) {
			pos = new Vector3 (0.35f, 0, 0);	
		}
		currentSpeed += acc * Time.deltaTime;
		if (currentSpeed > maxSpeed) {
			currentSpeed = maxSpeed;
		}
		rigidbody.velocity = transform.forward * currentSpeed;
		transform.rotation = Quaternion.RotateTowards (transform.rotation, currentRotation, Time.deltaTime * 10f);
		if (Input.GetKey ("a")) {
			transform.position -= pos;
			transform.Rotate (0, 0, 4);
		}
		if (Input.GetKey ("d")) {
			transform.position += pos;
			transform.Rotate (0, 0, -4);
		}		
		transform.rotation = Quaternion.Slerp (transform.rotation, currentRotation, Time.deltaTime * rotationSpeed);
	}

	public void SlowSpeed(){
			currentSpeed = 1f;
	}

	public void Turn (bool isToRight)
	{
		currentRotation = Quaternion.Euler (0f, currentRotation.eulerAngles.y + (isToRight ? 90f : -90f), 0f);	
		
	}
}
