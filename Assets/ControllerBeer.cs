using UnityEngine;
using System.Collections;

public class ControllerBeer : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<Player>().Damage(-1) ;
            LocalDatabase.instance.addApocalypse(2);
        }
    }
}
