using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour
{
	public int maxHealth = 100;
	public int curHealth = 100;
	public float healthBar;
	
	void Start ()
	{
		healthBar = Screen.width / 2;
	}

	void Update ()
	{
		addCurHealth (0);
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
	public void CollisionObject(bool healthCur){
		if(healthCur){
			curHealth -= 5;	
		}
	}
	public void CollisionTerror(bool healthCur1){
		if(healthCur1){
			curHealth -= Random.Range(1, 5);	
		}
	}
	
	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "Obstacle") {
			GetComponent<MoveTank> ().SlowSpeed();
			curHealth -= 5;
		}
		else if(collision.gameObject.tag == "Bullet"){
			curHealth -= Random.Range(1, 5);	
		}
	}
}