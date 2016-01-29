using UnityEngine;
using System.Collections;

public class EndlessMoving : MonoBehaviour
{
	Vector3 spawnPosition;
	
	void Start()
	{
		spawnPosition = transform.position;
	}

	void FixedUpdate ()
	{
		transform.position += WorldManager.instance.moveSpeed * Vector3.left;
		if(WorldManager.instance.spawnPosition.x - transform.position.x >= WorldManager.instance.maxMoveDistance)
		{
			Destroy(gameObject);
			WorldManager.instance.InstantiatePart();
		}
	}
}
