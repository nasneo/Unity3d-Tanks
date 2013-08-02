using UnityEngine;
using System.Collections;

public class RotationTank : MonoBehaviour
{
	
	public Transform tank;
	
	void Update ()
	{
		if (transform.position.z - tank.transform.position.z < 5) {
			if (Input.GetKeyDown ("d")) {
				tank.GetComponent<MoveTank> ().Turn (true);
			} else if (Input.GetKeyDown ("a")) {
				tank.GetComponent<MoveTank> ().Turn (false);
			}
		}
	}
}
