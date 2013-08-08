using UnityEngine;
using System.Collections;

public class MoveTank : MonoBehaviour
{

	public float rotationSpeed = 2f;
	public float rate = 0.5f;
	private float last;
	private Quaternion desiredRotation;
	private GameObject lastUsedCorner;
	public float acc;
	public float maxSpeed;
	private float currentSpeed;
	private Vector3 pos;
	
	void Start ()
	{
		transform.position = new Vector3 (0, 0.5f, 0);
		desiredRotation = Quaternion.identity;
	}

	void Update ()
	{
		currentSpeed += acc * Time.deltaTime;
		if (currentSpeed > maxSpeed) {
			currentSpeed = maxSpeed;
		}
		
		transform.rotation = Quaternion.RotateTowards (transform.rotation, desiredRotation, Time.deltaTime * 10f);
		if (Input.GetKey ("a")) {
			transform.position -= Quaternion.Euler (0f, transform.rotation.eulerAngles.y, 0f) * new Vector3 (0.3f, 0, 0);
			transform.Rotate (0, 0, 4);
		}
		if (Input.GetKey ("d")) {
			transform.position += Quaternion.Euler (0f, transform.rotation.eulerAngles.y, 0f) * new Vector3 (0.3f, 0, 0);
			transform.Rotate (0, 0, -4);
		}		
		transform.rotation = Quaternion.Slerp (transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
	}
	
	public void FixedUpdate ()
	{	
		rigidbody.velocity = transform.forward * currentSpeed;
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "PathCorner") {
			// Turn
			Transform cornerTR = other.transform;
			desiredRotation = cornerTR.rotation;
			
			// Create next Block
			PathBlock currentPB = cornerTR.parent.GetComponent<PathBlock> ();
			
			currentPB.nextPB.CreateNextPathBlock ();
			Destroy (currentPB.gameObject, 5f);
		}
	}

	public void SlowSpeed ()
	{
		currentSpeed = 1f;
	}
}
