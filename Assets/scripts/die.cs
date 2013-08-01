using UnityEngine;
using System.Collections;

public class die : MonoBehaviour {
	public int health = 30;
	
	void OnCollisionEnter(Collision collision){
		if(collision.relativeVelocity.magnitude > 1){
			health -= 10;	
		}
		if(health == 0){
				 Destroy(gameObject);
		}
	}
}
