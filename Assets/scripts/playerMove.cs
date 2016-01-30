using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour {

	const float MOVESPEED = 10;
	const float JUMPFORCE = 24;

    bool isAttacking;
    bool isCrounching;
    bool isGrounded;
    Rigidbody2D rb;

    Vector3 feetPosition { get { return transform.position + Vector3.down * transform.localScale.y * 0.5f; } }

    Transform tf;
    Transform scalepivot;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
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
				rb.velocity += Vector2.up * JUMPFORCE;
				//rb.AddForce(new Vector3(0, JUMPFORCE,0));
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
		Collider2D hit = Physics2D.OverlapPoint(feetPosition + Vector3.down * 0.3f);
		
        if (hit != null)
		{
			if (hit.tag == "floor")
			{
				isGrounded = true;
            }
		}

	}
	
    void OnCollisionExit2D(Collision2D other){
       if(other.gameObject.tag == "floor")
		{
            isGrounded = false;
        }
    }
}
