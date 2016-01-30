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
	
    Transform scalepivot;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
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
            transform.localScale -= new Vector3(0, 0.5f, 0);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow)){
            transform.localScale += new Vector3(0, 0.5f, 0);
        }

        var move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += move * MOVESPEED * Time.deltaTime;

    }

	void FixedUpdate()
	{
		Physics2D.IgnoreLayerCollision(8,  9, isCrounching);
	}

	void GroundedCheck()
	{
		Collider2D col = Physics2D.OverlapCircle(feetPosition, 0.2f);
        if ( col != null )
		{
			if(col.gameObject.layer == 9)
			{
				isGrounded = true;
			}
		}
	}
	
    void OnCollisionExit2D(Collision2D other)
	{
       if(other.gameObject.layer == 9)
		{
            isGrounded = false;
        }
    }
}
