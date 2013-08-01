using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {
	public int health = 50;
	public Transform tank;
	public GameObject projectile;
	public float speed = 100f;
	public Vector3 bulletOffset;
	private float lastshoot;
	public float rate = 0.5f;
	
	void Start () {
	}
	
	void Fire(){
		GameObject instantiatedProjectile = Instantiate(projectile, transform.position + transform.rotation * bulletOffset, transform.rotation) as GameObject;
				instantiatedProjectile.rigidbody.velocity = ((tank.position - transform.position).normalized * speed);	
		lastshoot = Time.time;
	}
	
	void Update () {
		if((transform.position.z - tank.transform.position.z)  < 100){
				transform.LookAt(tank.position);	
		}
		
		if(lastshoot + rate < Time.time){
			Fire();	
		}
	}
}
