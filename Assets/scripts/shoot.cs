using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
	public GameObject projectile;
	public float speed = 1000f;
	public float rate;
	public Vector3 initPosition;
	public Transform tower;
	private float lastshoot;
//	public AudioClip shoot;
	
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
		GameObject instantiatedProjectile = Instantiate (projectile, transform.position + tower.rotation * initPosition, tower.rotation) as GameObject;
		instantiatedProjectile.rigidbody.velocity = rigidbody.velocity + tower.rotation * new Vector3 (0f, 0f, speed);
		audio.Play ();
		lastshoot = Time.time;
	}
}
