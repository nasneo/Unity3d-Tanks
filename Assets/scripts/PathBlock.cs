using UnityEngine;
using System.Collections;

public class PathBlock : MonoBehaviour
{
	public float myLength = 100f;
	public Transform obstaclesParent;
	public Transform wall_l;
	public Transform wall_r;
	public Transform ground;
	public GameObject obstaclePrefab;
	public GameObject terrorist;
	private float prePosition = 15;
	public Transform myCorner;
	[HideInInspector]
	public PathBlock nextPB;
	[HideInInspector]
	public PathBlock previousPB;

	// Use this for initialization
	void Start ()
	{
		if (obstaclesParent == null) {
			obstaclesParent = GameObject.Find ("_obstacles").transform;
		}
		myCorner = transform.Find ("Corner");
		GenerateObjects ();
		
		wall_l = CreateWall (1000, 20).transform;
		wall_l.localPosition = new Vector3(-10f, 0f, 0f);
		wall_l.localRotation = Quaternion.Euler(0f , -90f, 0f);
		
		wall_r = CreateWall (1000, 20).transform;
		wall_r.localPosition = new Vector3(10f , 0f, 1000f);
		wall_r.localRotation = Quaternion.Euler(0f, 90f, 0f);

	}
	
	// Update is called once per frame
	void Update ()
	{
		//SetLength (myLength);

	}
	
	GameObject CreateWall (float length, float height)
	{
		GameObject newWallGO = new GameObject ("wall", typeof(MeshFilter), typeof(MeshRenderer));
		newWallGO.transform.parent = transform;
		
		int sectionsNumber = (int)(length / height);
		Mesh newMesh = new Mesh ();
		newMesh.hideFlags = HideFlags.DontSave;
		
		Vector3[] vertices = new Vector3[sectionsNumber * 4];
		int[] triangles = new int[sectionsNumber * 6];
		Vector3[] normals = new Vector3[sectionsNumber * 4];
		Vector2[] uvs = new Vector2[sectionsNumber * 4];
		
		for (int i = 0; i < sectionsNumber; i++) {
			vertices [i * 4 + 0] = new Vector3 (i * height, 0, 0);
			vertices [i * 4 + 1] = new Vector3 ((i + 1) * height, 0, 0);
			vertices [i * 4 + 2] = new Vector3 (i * height, height, 0);
			vertices [i * 4 + 3] = new Vector3 ((i + 1) * height, height, 0);
			
			triangles [i * 6 + 0] = i * 4 + 0;
			triangles [i * 6 + 1] = i * 4 + 2;
			triangles [i * 6 + 2] = i * 4 + 1;
			
			normals [i * 4 + 0] = -Vector3.forward;
			normals [i * 4 + 1] = -Vector3.forward;
			normals [i * 4 + 2] = -Vector3.forward;
			normals [i * 4 + 3] = -Vector3.forward;
			
			triangles [i * 6 + 3] = i * 4 + 2;
			triangles [i * 6 + 4] = i * 4 + 3;
			triangles [i * 6 + 5] = i * 4 + 1;
			
			float xOffset = Random.value > 0.5f ? 0 : 0.5f;
			float yOffset = Random.value > 0.5f ? 0 : 0.5f;
			
			uvs [i * 4 + 0] = new Vector2 (xOffset + 0f, yOffset + 0f);
			uvs [i * 4 + 1] = new Vector2 (xOffset + 0.5f, yOffset + 0f);
			uvs [i * 4 + 2] = new Vector2 (xOffset + 0f, yOffset + 0.5f);
			uvs [i * 4 + 3] = new Vector2 (xOffset + 0.5f, yOffset + 0.5f);

		}
		newMesh.vertices = vertices;
		newMesh.triangles = triangles;
		newMesh.uv = uvs;
		newWallGO.GetComponent<MeshFilter> ().sharedMesh = newMesh;
		
		MeshRenderer newWallMR = newWallGO.GetComponent<MeshRenderer> ();
		newWallMR.sharedMaterial = LevelGenerator.Instance.wallMaterial;
//		newWallMR.castShadows = false;
//		newWallMR.receiveShadows = false;
		
		return newWallGO;
	}
	
	public void SetLength (float newLength)
	{
		ground.localPosition = new Vector3 (ground.localPosition.x, ground.localPosition.y, 5 * newLength);
		ground.localScale = new Vector3 (ground.localScale.x, ground.localScale.y, newLength);
		ground.renderer.material.mainTextureScale = new Vector2 (1, newLength);
//		wall_l.localPosition = new Vector3 (wall_l.localPosition.x, wall_l.localPosition.y, 5 * newLength);
//		wall_l.localScale = new Vector3 (wall_l.localScale.x, wall_l.localScale.y, newLength);
//		wall_l.renderer.material.mainTextureScale = new Vector2 (1, newLength);
////		wall_r.localPosition = new Vector3 (wall_r.localPosition.x, wall_r.localPosition.y, 5 * newLength);
//		wall_r.localScale = new Vector3 (wall_r.localScale.x, wall_r.localScale.y, newLength);
//		wall_r.renderer.material.mainTextureScale = new Vector2 (1, newLength);
	}
	
	/// <summary>
	/// Creates the next path block at the end of own corner.
	/// </summary>
	public void CreateNextPathBlock ()
	{
		nextPB = LevelGenerator.Instance.CreatePathBlock (myCorner.position + myCorner.forward * 10f, myCorner.rotation);
		nextPB.previousPB = this;
	}
	
	void GenerateObjects ()
	{
		for (int i = 0; i < (ground.localScale.z / 2); i++) {
			//new obstacle
			GameObject newObstacle = Instantiate (obstaclePrefab) as GameObject;
			newObstacle.transform.parent = transform;
			newObstacle.transform.localPosition = new Vector3 (Random.Range (-8, 8), -0.4f, prePosition + Random.Range (15, 25)); 
			newObstacle.transform.localRotation = Quaternion.identity;
			prePosition = newObstacle.transform.localPosition.z;
			//new terrorist
			if(Random.value < 0.5f){
			GameObject newTerrorist = Instantiate (terrorist) as GameObject;
			newTerrorist.transform.parent = transform;
			newTerrorist.transform.localPosition = new Vector3 (Random.Range (-8 , 8), 1, newObstacle.transform.localPosition.z + 10);
			newTerrorist.transform.localRotation = Quaternion.identity;
			}
		}
	}
}
