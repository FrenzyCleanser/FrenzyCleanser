﻿using UnityEngine;
using System.Collections;

public class ControllerBowlingball : MonoBehaviour {

    Rigidbody2D rb;

    // Use this for initialization
    void Start ()
	{
        Renderer rend = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(900.0f, 30.0f));
        StartCoroutine(WaitAndDie(5.0F));
        rend.material.color = Color.red;

    }

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			other.gameObject.GetComponent<Player>().Damage();
		}
	}

    IEnumerator WaitAndDie(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}
