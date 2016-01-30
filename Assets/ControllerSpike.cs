using UnityEngine;
using System.Collections;

public class ControllerSpike : MonoBehaviour {

    Rigidbody2D rb;

	// Use this for initialization
	void Start ()
	{

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(600.0f, 1100.0f));
        StartCoroutine(WaitAndDie(5.0F));
    }

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			other.gameObject.GetComponent<Player>().Damage();
		}
	}


	IEnumerator WaitAndDie(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Object.Destroy(this.gameObject);
    }
}
