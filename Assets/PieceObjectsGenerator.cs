using UnityEngine;
using System.Collections;

public class PieceObjectsGenerator : MonoBehaviour
{
	//to make sure it does not spawn to object in a seam.
	const float safeMargins = 2;
	public GameObject[] objectsToPlace;

	public float spawnFieldHeightMin,spawnFieldHeightMax;
	
	public int spawnCountMin, spawnCountMax;


	void Start ()
	{
		int spawnCount = Random.Range(spawnCountMin, spawnCountMax);
		for (int i = 0; i < spawnCount; i++)
		{
			GameObject newObject = Instantiate<GameObject>(objectsToPlace[Random.Range(0, objectsToPlace.Length - 1)]);
			newObject.transform.parent = transform;

			newObject.transform.position = transform.position + 50 * Vector3.left + 5 * Vector3.back;
			newObject.transform.position += Vector3.right * Random.Range((100.0f * i) / spawnCount, (100.0f * i + 1) / spawnCount);
		}
	
	}
}
