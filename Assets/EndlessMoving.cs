using UnityEngine;
using System.Collections;

public class EndlessMoving : MonoBehaviour
{
	Vector3 spawnPosition;
	public float speed = 1.0f;
	
	void Start()
	{
		spawnPosition = transform.position;
	}

	void FixedUpdate ()
	{
		transform.position += speed * Vector3.left;
		if(WorldManager.instance.spawnPosition.x - transform.position.x >= WorldManager.instance.maxMoveDistance)
		{
			Destroy(gameObject);
			WorldManager.instance.InstantiatePart();
		}
	}
}
