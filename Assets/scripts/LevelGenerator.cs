using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour
{
	#region Singletone
	private static LevelGenerator _instance;
	
	public static LevelGenerator Instance {
		get {
			if (_instance == null) {
				_instance = GameObject.Find ("_gameManager").GetComponent<LevelGenerator> ();
			}
			return _instance;
		}
	}
	#endregion
	
	public Transform tank;
	public GameObject pathBlockPrefab;
	public PathBlock nextPathBlock;
	public PathBlock currentPathBlock;
	public Material wallMaterial;
	
	void Start ()
	{
		Screen.showCursor = false;
		Screen.lockCursor = true;
		
		if (tank == null) {
			tank = GameObject.FindGameObjectWithTag ("Tank").transform;
		}
		int multiplier = (Random.value > 0.5f ? 1 : -1);
		PathBlock newPB = CreatePathBlock (Vector3.zero, Quaternion.identity);
		newPB.CreateNextPathBlock ();
	}

	void Update ()
	{

	}
	
	/// <summary>
	/// Creates the path block at position and rotation.
	/// </summary>
	/// <returns>
	/// Created path block.
	/// </returns>
	/// <param name='newBlockPosition'>
	/// New block position.
	/// </param>
	/// <param name='newBlockRotation'>
	/// New block rotation.
	/// </param>
	public PathBlock CreatePathBlock (Vector3 newBlockPosition, Quaternion newBlockRotation)
	{
		PathBlock newPathBlock = (Instantiate (
				pathBlockPrefab,
				newBlockPosition,
				newBlockRotation
			) as GameObject).GetComponent<PathBlock> ();
		
		return newPathBlock;
	}
}
