using UnityEngine;

public abstract class BeseObstacle : MonoBehaviour
{
	
	void OnTriggerStay2D (Collider2D other)
	{
		if(other.tag == "Player")
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				PriestAction();
			}
		}
		else if (other.tag == "Devil")
		{
			DevilAction();
		}
	}

	public abstract void PriestAction();
	public abstract void DevilAction();
}
