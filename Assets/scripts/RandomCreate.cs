using UnityEngine;
using System.Collections;

public class RandomCreate : MonoBehaviour
{
	public GameObject projectile;
	private Vector3 pos;
	public Transform tank;
	public float rateCreate = 20f;
	private float lastcreate = 0f;
	
	void Create ()
	{
		GameObject instantiatedProjectile = Instantiate (projectile, new Vector3 (Random.Range (-3, 4), 2, tank.transform.position.z + 70), transform.rotation) as GameObject;
		lastcreate = Time.time;
	}
	
	void Update ()
	{
		if (lastcreate + rateCreate < Time.time) {
			Create ();
		}
	}
}
