using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour
{
	public int health = 50;
	public Transform tank;
	public GameObject projectile;
	public float speedShoot = 100f;
	public Vector3 bulletOffset;
	private float lastshoot;
	public float rate = 0.5f;
	
	void Start ()
	{
		if(tank == null){
			tank = GameObject.Find("Tank").transform;
		}
	}
	
	void Fire ()
	{
		GameObject instantiatedProjectile = Instantiate (projectile, transform.position + transform.rotation * bulletOffset, transform.rotation) as GameObject;
		instantiatedProjectile.rigidbody.velocity = ((tank.position - transform.position).normalized * speedShoot);	
		lastshoot = Time.time;
	}
	
	void Update ()
	{
		if (Vector3.Distance (transform.position, tank.transform.position) < 40 && (lastshoot + rate < Time.time)) {
			transform.LookAt (tank.position);
			Fire ();
		}
	}

	void OnCollisionEnter (Collision collision)
	{
		if (collision.relativeVelocity.magnitude > 1) {
			health -= 10;	
		}
		if (health == 0) {
			Destroy (gameObject);
		}
	}
}
