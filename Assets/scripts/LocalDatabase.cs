using UnityEngine;
using System.Collections;

public class LocalDatabase : MonoBehaviour {


    int currentState = 2;
    int newState = 2;
    public float speed = 50;
    public int mana = 100;
    private float apocalypseMax = 100;
    public float apocalypseCurrent = 50;
    public GameObject devil;

    DevilAttack devilatack;

    public void Start(){
        devilatack = (DevilAttack)devil.GetComponent(typeof(DevilAttack));
    }

    public float getApocalypseNormalized(){
        return apocalypseCurrent / apocalypseMax;
    }

    public void addApocalypse(float addValue){
        apocalypseCurrent += addValue;
        checkDevilState(); 
    }

    float[,] devilAttackList = new float[5, 2] { { -1000, 0.2f }, { 0.2f, .4f }, { .4f, .6f }, { .6f, .8f }, { .8f, 1000 } };

    private void checkDevilState(){
        if(getApocalypseNormalized() < devilAttackList[currentState, 0]){
            currentState--;
            devilatack.setState(currentState);
        }
        else if(getApocalypseNormalized() > devilAttackList[currentState, 1]){
            currentState++;
            devilatack.setState(currentState);
        }
    }
}
