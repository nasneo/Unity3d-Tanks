using UnityEngine;
using System.Collections;

public class RotationTank : MonoBehaviour
{
	
	public Transform tank;
	
	void Update ()
	{
		if (Vector3.Distance (tank.transform.position, transform.position) < 5f) {
			if (Input.GetKeyDown ("d")) {
				tank.GetComponent<MoveTank> ().Turn (true);
			} else if (Input.GetKeyDown ("a")) {
				tank.GetComponent<MoveTank> ().Turn (false);
			}
		}
	}
}
