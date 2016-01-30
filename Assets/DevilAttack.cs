using UnityEngine;
using System.Collections;

public class DevilAttack : MonoBehaviour {

    bool inBite;
    float posX;
    float startX;
    Vector3 startPos;

    public void Start(){
        startPos = GetComponent<Transform>().position;
        posX = startPos.x;
        startX = posX;
        inBite = false;
    }


    public void setState(int state){
        runAction(state);
    }


    public void Update(){
        if (inBite){
            if(posX < startX + .03){
                posX += 0.0005f;
                Vector3 temp = new Vector3(posX-startX, 0, 0);
                transform.position += temp;
            }
            else{
                inBite = false;
                posX = startPos.x;
                transform.position = startPos;
            }
        }
    }


    public void runAction(int state){

        Debug.Log("wtf");
        switch (state){
            case 0:{
                    Debug.Log("In action state = " + state + " Throwing spike ");
                    break;
            }
            case 1:{
                    Debug.Log("In action state = " + state + " Bite ");
                    inBite = true;
                    break;
                }
            default:
                Debug.Log("In action state = " + state + " Not mappet yet ");
                break;
        }

    }
}
