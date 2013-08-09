using UnityEngine;
using System.Collections;

public class MoveTank : MonoBehaviour
{

	public float rotationSpeed = 2f;
	private float last;
	private Quaternion desiredRotation;
	private GameObject lastUsedCorner;
	public float acc;
	private float currentSpeed;
	private float addSpeed = 0.3f;
	private float maxSpeed = 20;
	public float rate = 0f;
	private float rateBetweenAddSpeed = 3f;
	private float lastAdd;
	private float rotation = 0.3f;
	private Vector3 pos;
	
	void Start ()
	{
		transform.position = new Vector3 (0, 1, 0);
		desiredRotation = Quaternion.identity;
	}

	void Update ()
	{
		currentSpeed += acc * Time.deltaTime;
		if (currentSpeed > maxSpeed) {
			currentSpeed = maxSpeed;
		}
		
		transform.rotation = Quaternion.RotateTowards (transform.rotation, desiredRotation, Time.deltaTime * 10f);
		
		float strafeValue = Input.GetAxis ("Horizontal");
		transform.position += Quaternion.Euler (0f, transform.rotation.eulerAngles.y, 0f) * new Vector3 (strafeValue * rotation, 0, 0);
		transform.Rotate (0, 0, strafeValue * -4);
			
		transform.rotation = Quaternion.Slerp (transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
		
		if (rateBetweenAddSpeed + lastAdd < Time.time) {
			AddMaxSpeed ();
		}
	}
	
	public void FixedUpdate ()
	{	
		rigidbody.velocity = transform.forward * currentSpeed;
	}
	
	void AddMaxSpeed ()
	{
		maxSpeed += 0.3f;
		currentSpeed += 0.2f;
		lastAdd = Time.time;
		if (rotation < 0.4f) {
			rotation += 0.001f;
		}
		Debug.Log (maxSpeed);
		Debug.Log (rotation);
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
		currentSpeed *= 0.5f;
	}
}
