using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour
{
	public int maxHealth = 100;
	public int curHealth = 100;
	public float healthBar;
	public float rate = 2f;
	public float lastCollision;
	public GameObject graphics;
	private float rateSetActive = 0.3f;
	private float lastSetActive;
	
	void Start ()
	{
		healthBar = Screen.width / 2;
	}

	void Update ()
	{
		addCurHealth (0);
		if (rate + lastCollision < Time.time) {
			gameObject.GetComponent<BoxCollider> ().collider.isTrigger = false;
		}	
		if (rateSetActive + lastSetActive < Time.time) {
			graphics.SetActive (true);	
		}
		if(curHealth < 0 || curHealth == 0){
			Application.LoadLevel("GameOver");
		}
	}

	void OnGUI ()
	{
		GUI.Box (new Rect (10, 10, healthBar, 20), curHealth + "/" + maxHealth);
	}

	public void addCurHealth (int adj)
	{
		curHealth += adj;
		
		if (curHealth < 0) {
			curHealth = 0;
		}
		if (curHealth > maxHealth) {
			curHealth = maxHealth;	
		}
		healthBar = (Screen.width / 2) * (curHealth / (float)maxHealth);
	}

	public void CollisionObject (bool healthCur)
	{
		if (healthCur) {
			curHealth -= 5;	
		}
	}

	public void CollisionTerror (bool healthCur1)
	{
		if (healthCur1) {
			curHealth -= Random.Range (1, 5);	
		}
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Obstacle") {
			GetComponent<MoveTank> ().SlowSpeed ();
			curHealth -= 5;
			gameObject.GetComponent<BoxCollider> ().collider.isTrigger = true;
			lastCollision = Time.time;
			graphics.SetActive (false);
			lastSetActive = Time.time;	
			
		} else if (other.tag == "Bullet") {
			curHealth -= Random.Range (1, 5);	
		}
	}
}