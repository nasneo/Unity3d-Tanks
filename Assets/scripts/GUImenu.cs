using UnityEngine;
using System.Collections;

public class GUImenu : MonoBehaviour
{
	
	void OnGUI ()
	{
		GUI.Box (new Rect (350, 50, Screen.width / 2, Screen.height / 2), "Tank");	
		if (GUI.Button (new Rect (360, 100, Screen.width / 2 - 20, Screen.height / 10 - 10), "Start")) {
			Application.LoadLevel("Tanks");
		}
		if (GUI.Button (new Rect (360, 180, Screen.width / 2 - 20, Screen.height / 10 - 10), "Settings")) {
			
		}
		if (GUI.Button (new Rect (360, 260, Screen.width / 2 - 20, Screen.height / 10 - 10), "Quit")) {
			
		}
	}
	
}
