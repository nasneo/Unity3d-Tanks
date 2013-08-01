using UnityEngine;
using System.Collections;

public class tank : MonoBehaviour {
	public int maxHealth = 100;
	public int curHealth = 100;
	
	private int damage = 10;
	
	public float healthBar;
	
	void Start(){
		healthBar = Screen.width / 2;
	}
	void Update(){
		addCurHealth(0);
	}
	void OnGUI(){
		GUI.Box(new Rect(10, 10, healthBar, 20), curHealth + "/" + maxHealth);
	}
	public void addCurHealth(int adj){
		curHealth += adj;
		
		if(curHealth < 0){
			curHealth = 0;
		}
		if(curHealth > maxHealth){
			curHealth = maxHealth;	
		}
		healthBar = (Screen.width / 2) * (curHealth / (float)maxHealth);
	}
	void OnCollisionEnter(Collision collision){
		if(collision.relativeVelocity.magnitude > 0){
			curHealth -= 10;	
		}
	}
}