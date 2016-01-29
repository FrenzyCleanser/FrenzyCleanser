using UnityEngine;
using System.Collections;

public class LocalDatabase : MonoBehaviour {

    public float speed = 50;
    private float apocalypseMax = 100;
    private float apocalypseCurrent = 50;

    public float getApocalypseNormalized(){
        return apocalypseCurrent / apocalypseMax;
    }

    public float addApocalypse(float addValue){
        return apocalypseCurrent += addValue;
    }
}
