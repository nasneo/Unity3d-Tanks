using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{

	public GameObject ObjectToFollow;
	
	void Start ()
	{
	
	}
	
	void Update ()
	{
		transform.position = ObjectToFollow.transform.position + ObjectToFollow.transform.rotation * new Vector3 (0f, 4f, -5f);
		transform.rotation = Quaternion.Euler (14f, ObjectToFollow.transform.rotation.eulerAngles.y, 0f);
		//gameObject.transform.position = new Vector3(ObjectToFollow.transform.localPosition.x, 5f, ObjectToFollow.transform.position.z - 5);
		//gameObject.transform.rotation = Quaternion.Euler(14f, ObjectToFollow.transform.rotation.y , 0f);
	}
}
