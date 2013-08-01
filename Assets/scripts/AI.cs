using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {
	public int health = 50;
	public Transform terror;
	
	
	void Start () {
	
	}
	
	void Update () {
		
	}
	
	void OnCollisionEnter(Collision collision){
		if(collision.relativeVelocity.magnitude > 1){
			health -= 10;	
		}
		if(health == 0){
			Destroy(GameObject);
		}
	}
}
