using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {
	public GameObject projectile;
	public float speed = 1000f;
	public Vector3 initPosition;
	public Transform tower;
	
	
	void Update () {
		// Tower rotation
		//Debug.Log(Input.GetAxis("Mouse X"));
		tower.Rotate(0f, Input.GetAxis("Mouse X"), 0f);
		
		// Fire
		if(Input.GetButtonDown("Fire1")){
			GameObject instantiatedProjectile = Instantiate(projectile, transform.position + tower.rotation * initPosition, transform.rotation) as GameObject;
			instantiatedProjectile.rigidbody.velocity = tower.rotation * (rigidbody.velocity + new Vector3(0f, 0f, speed));
		}
	}
}
