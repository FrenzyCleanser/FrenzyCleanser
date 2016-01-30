using UnityEngine;
using System.Collections;

public class DevilAttack : MonoBehaviour {

    
    public void setState(int state){
        runAction(state);
    }

    public void runAction(int state){
        Debug.Log("In action state = " + state);
    }
}
