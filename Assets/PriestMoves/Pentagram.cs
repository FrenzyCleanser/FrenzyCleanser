using System;
using UnityEngine;

public class Pentagram : BeseObstacle
{
	public override void ObstacleAction()
	{
		Destroy(gameObject);
	}
}
