using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	const float MOVESPEED = 10;
	const float JUMPFORCE = 24;

	int maxHealth = 5;
	public int health;
    public Animator anim;
    bool isAttacking;
    bool isCrounching;
    bool isGrounded;
	[HideInInspector]
	public Rigidbody2D rb;
    Vector3 feetPosition { get { return transform.position + Vector3.down * transform.localScale.y * 0.5f; } }
    BoxCollider2D col;
    Transform scalepivot;

    // Use this for initialization
    void Start ()
	{
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        isGrounded = false;
        //anim.SetBool("isGrounded", isGrounded);
        isAttacking = false;
        col = GetComponent<BoxCollider2D>();
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
        if (Input.GetKey(KeyCode.DownArrow)){
            anim.SetBool("isSliding", true);
            col.size = new Vector2(1.0f, 0.5f);
            col.offset = new Vector2(0.0f, -0.30f);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)){
			transform.position -= Vector3.up * 0.5f;
            
        }
        if (Input.GetKeyUp(KeyCode.DownArrow)){
            anim.SetBool("isSliding", false);
			transform.position += Vector3.up * 0.5f;
            col.size = new Vector2(1.0f, 1.73f);
            col.offset = new Vector2(0.0f, 0.36f);

        }

        var move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += move * MOVESPEED * Time.deltaTime;

    }

	void FixedUpdate()
	{
        GroundedCheck();
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
                anim.SetBool("isGrounded", true);
                
            }
		}
	}
	
    void OnCollisionExit2D(Collision2D other)
	{
       
       if(other.gameObject.layer == 9){
            isGrounded = false;
            anim.SetBool("isGrounded", false);
        }
    }

	public void Damage()
	{
		Damage(1);
	}

	public void Damage(int i){
       health -= i;
       if(health > maxHealth){
            health = maxHealth;
        } 
		HealthUpdate();
	}

	void HealthUpdate()
	{
		LocalDatabase.instance.healthBar.fillAmount = (float)health / maxHealth;
		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		//Play death animation
		//Pause game - GAAME OVER
	}
}
