using UnityEngine;

public abstract class BeseObstacle : MonoBehaviour
{
	
	void OnTriggerStay (Collider other)
	{
		if(other.tag == "Player")
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				
				ObstacleAction();
			}
		}
	}

	public abstract void ObstacleAction();
	
}
