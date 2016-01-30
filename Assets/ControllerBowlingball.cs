using UnityEngine;
using System.Collections;

public class ControllerBowlingball : MonoBehaviour {

    Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        Debug.Log("spike is alive");
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(600.0f, 30.0f));
        StartCoroutine(WaitAndDie(5.0F));
    }

    IEnumerator WaitAndDie(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        Object.Destroy(this.gameObject);
    }
}
