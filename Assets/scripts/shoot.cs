using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour
{
	public GameObject projectile;
	public float speed = 1000f;
	public float rate;
	public Vector3 initPosition;
	public Transform tower;
	private float lastshoot;
	
	void Update ()
	{
		// Tower rotation
		tower.Rotate (0f, Input.GetAxis ("Mouse X"), 0f);
		
		if (Input.GetButtonDown ("Fire1") && (lastshoot + rate < Time.time)) {
			Fire ();	
		}
	}

	void Fire ()
	{
		GameObject instantiatedProjectile = Instantiate (projectile, transform.position + tower.rotation * initPosition, transform.rotation) as GameObject;
		instantiatedProjectile.rigidbody.velocity = tower.rotation * (rigidbody.velocity + new Vector3 (0f, 0f, speed));
		lastshoot = Time.time;
	}
}
