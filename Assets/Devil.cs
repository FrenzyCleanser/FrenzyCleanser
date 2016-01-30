﻿using UnityEngine;
using System.Collections;

public class Devil : MonoBehaviour {

	//We'll add many more if needed
	public enum DevilAttack : int
	{
		Bite = 0,
		Throw = 1,
		ThrowSpike = 2,
		Bowl = 3,
		Supersaiyan = 4
	}

    bool inBite;
    bool reachedPosition;
    float posX;
    Vector3 startPos;
    Vector3 endPos;
    bool inAction;
    public Transform spike;
    public Transform throwPosition;
    public Transform bowl;
    public Transform BowlPosition;

    public void setState(int state)
	{
        runAction((DevilAttack)state);
    }

    public Transform startMarker;
    public Transform endMarker;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;
    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
        inAction = false;

    }
    void Update()
    {
        if (inBite){
            
            if (!reachedPosition){
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, endMarker.position, step);
                if (transform.position.x >= endMarker.position.x - .05f){
                    reachedPosition = true;
                }
            }
            else{
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, startMarker.position, step);
                if (transform.position.x <= startMarker.position.x + .05f){
                    reachedPosition = false;
                    inBite = false;
                    inAction = false;
                }
            }
        }
    }

    public void runAction(DevilAttack state){
        if (inAction){
            return;
        }
        switch (state){
            case DevilAttack.Bite:
                inAction = true;
                inBite = true;
                Debug.Log("In action state = " + state);
				break;
			case DevilAttack.Throw:
				Debug.Log("In action state = " + state);
				break;
			case DevilAttack.ThrowSpike:
                inAction = true;
                initSpike();
                Debug.Log("In action state = " + state);
				break;
			case DevilAttack.Bowl:
                inAction = true;
                initBowl();
                Debug.Log("In action state = " + state);
                break;
			case DevilAttack.Supersaiyan:
				break;
            default:
                Debug.Log("In action state = " + state);
                break;
        }
    }

    private void initSpike()
	{
        Instantiate(spike, throwPosition.position, transform.rotation);
        inAction = false;
    }

    private void initBowl()
	{
        Instantiate(bowl, BowlPosition.position, transform.rotation);
        inAction = false;
    }

	//I'll deal with this later on...
	IEnumerator BiteAttack()
	{
		while (true)
		{
			yield return null;
        }
	}

}
