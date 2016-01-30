using UnityEngine;
using System.Collections;

public class ControllerBowlingball : MonoBehaviour {

    Rigidbody2D rb;

    // Use this for initialization
    void Start ()
	{
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(600.0f, 30.0f));
        StartCoroutine(WaitAndDie(5.0F));
    }

	void OnCollisionEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			other.GetComponent<Player>().Damage();
		}
	}

    IEnumerator WaitAndDie(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}
