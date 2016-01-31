using UnityEngine;
using System.Collections;

public class ControllerDirtyMagazine : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            LocalDatabase.instance.addApocalypse(10);
        }
    }
}
