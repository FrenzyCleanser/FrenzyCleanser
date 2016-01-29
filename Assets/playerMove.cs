using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour {

    bool isGrounded;
    Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        isGrounded = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space") && isGrounded){
            rb.AddForce(new Vector3(0, 300.0f,0));
        }        
    }

    void OnCollisionEnter(Collision other){
        Debug.Log("isGrounded == " + isGrounded);
        if (other.gameObject.tag == "floor"){
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision other){
       if(other.gameObject.tag == "floor"){
            isGrounded = false;
        }
    }


}
