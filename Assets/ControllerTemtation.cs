using UnityEngine;
using System.Collections;

public class ControllerTemtation : MonoBehaviour {

    public GameObject beer;
    public GameObject dirtyMagazine;
    public Transform spawnPoint;
    GameObject child;

    // Use this for initialization
    void Start () {
        int randomInt = Random.Range(0,2);
        if(randomInt == 0){
            child = Instantiate<GameObject>(beer);
            child.transform.position = spawnPoint.position;
            child.transform.parent = spawnPoint.transform;
        }
        else{
            child = Instantiate<GameObject>(dirtyMagazine);
            child.transform.position = spawnPoint.position;
            child.transform.parent = spawnPoint;

        }
    }
}
