using System;
using UnityEngine;

public class Pentagram : BeseObstacle
{
	
	public override void PriestAction()
	{
		Destroy(gameObject);
		LocalDatabase.instance.removeApocalypse(1);
	}

	public override void DevilAction()
	{
		Destroy(gameObject);
		LocalDatabase.instance.addApocalypse(3);
	}

}
