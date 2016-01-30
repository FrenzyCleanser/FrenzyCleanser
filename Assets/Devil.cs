using UnityEngine;
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
    float posX;
    Vector3 startPos;

    public void Start(){
        startPos = GetComponent<Transform>().position;
        posX = startPos.x;
        inBite = false;
    }


    public void setState(int state){
        runAction((DevilAttack)state);
    }


    public void Update(){
        if (inBite){
            if(posX < startPos.x + .03){
                posX += 0.0005f;
                Vector3 temp = new Vector3(posX-startPos.x, 0, 0);
                transform.position += temp;
            }
            else{
                inBite = false;
                posX = startPos.x;
                transform.position = startPos;
            }
        }
    }


    public void runAction(DevilAttack state)
	{
        switch (state){
            
            case DevilAttack.Bite:
				Debug.Log("In action state = " + state);
				inBite = true;
				break;
			case DevilAttack.Throw:
				Debug.Log("In action state = " + state);
				break;
			case DevilAttack.ThrowSpike:
				Debug.Log("In action state = " + state);
				break;
			case DevilAttack.Bowl:
				break;
			case DevilAttack.Supersaiyan:
				break;
            default:
                Debug.Log("In action state = " + state);
                break;
        }

    }
}
