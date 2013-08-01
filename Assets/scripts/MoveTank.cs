using UnityEngine;
using System.Collections;

public class MoveTank : MonoBehaviour {
	
	public float speed = 10f;
	public float rotationSpeed = 2f;
	
	void Start(){
		transform.position = new Vector3(0, 0.8f, 0);
	}
	
	void Update () {
		rigidbody.velocity = Vector3.forward * speed;
//		Debug.Log(rigidbody.velocity);
		//transform.position += new Vector3(30f*Time.deltaTime, 0, 0);
		if(Input.GetKey("a")){
			transform.position -= new Vector3(0.2f, 0, 0);
			transform.Rotate(0, 0, 2);
			transform.Rotate(0, 0, 0);
		}
		if(Input.GetKey("d")){
			transform.position += new Vector3(0.2f, 0, 0);
			transform.Rotate(0, 0, -2);
			transform.Rotate(0, 0, 0);
		}		
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, Time.deltaTime * rotationSpeed);
	}
}
