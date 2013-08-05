using UnityEngine;
using System.Collections;

public class DestroyBullet : MonoBehaviour
{

	void Update ()
	{
		Destroy (gameObject, 0.8f);
	}
}
