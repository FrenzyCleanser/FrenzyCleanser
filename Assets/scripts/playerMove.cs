﻿using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour {

	const float MOVESPEED = 10;
	const float JUMPFORCE = 300;

    bool isAttacking;
    bool isCrounching;
    bool isGrounded;
    Rigidbody rb;
    Vector3 position;
    Transform tf;
    Transform scalepivot;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
        isGrounded = false;
        isAttacking = false;

    }
	
	// Update is called once per frame
	void Update ()
	{

		//WHAT IS AN ATTACK EVEN?
        if (Input.GetKeyDown(KeyCode.X)){
            isAttacking = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl)){
            isAttacking = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			GroundedCheck();
			if(isGrounded)
			{
				rb.AddForce(new Vector3(0, JUMPFORCE,0));
			}
		}

        if (Input.GetKeyDown(KeyCode.DownArrow)){
            tf.localScale -= new Vector3(0, 0.5f, 0);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow)){
            tf.localScale += new Vector3(0, 0.5f, 0);
        }

        var move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += move * MOVESPEED * Time.deltaTime;

    }

	void GroundedCheck()
	{
		RaycastHit hit;
		if (Physics.Raycast(transform.position, Vector3.down, out hit, transform.localScale.y * 0.5f + 0.1f))
		{
			if (hit.collider.tag == "floor")
			{
				isGrounded = true;
            }
		}

	}

	//void OnCollisionEnter(Collision other){
 //       Debug.Log("isGrounded == " + isGrounded);
 //       if (other.gameObject.tag == "floor")
	//	{
 //           isGrounded = true;
 //       }
 //   }

    void OnCollisionExit(Collision other){
       if(other.gameObject.tag == "floor")
		{
            isGrounded = false;
        }
    }


}