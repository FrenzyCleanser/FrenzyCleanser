using UnityEngine;
using System.Collections;

public class Devil : MonoBehaviour {

	//We'll add many more if needed
public enum DevilAttack : int
{
        PissedOff = 0,
        Angry = 1,
        Irritated = 2,
        Annoyed = 3,
        Harmless = 4
}
	bool hitPlayer = false;
    float waitTime;
    float posX;
    Vector3 startPos;
    bool inAction;
    public Transform spike;
    public Transform throwPosition;
    public Transform bowl;
    public Transform BowlPosition;
    public Transform startMarker;
    public Transform endMarker;
    public float speed = 1.0F;
    public Animator anim;

    public void setState(int state){
        runAction((DevilAttack)state);
    }

    private float startTime;

    void Start(){
	startPos = transform.position;
        startTime = Time.time;
        inAction = false;
        waitTime = 5.0f;
        StartCoroutine(runAction());       
    }

    IEnumerator runAction()
{
        while (true){
            yield return new WaitForSeconds(waitTime);
            if (!inAction){
                var randomInt = Random.Range(0, 3);
                inAction = true;
                if (randomInt == 0)
                {
                    StartCoroutine("BiteAttack", LocalDatabase.instance.player.transform.position);
                }
                else if (randomInt == 1)
                {
                    initSpike();
                }
                else if (randomInt == 2)
                {
                    initBowl();
                }
            }
            Debug.Log("running action. Delay = " + waitTime);
        }
    
}

    public void runAction(DevilAttack state){
        switch (state){
            case DevilAttack.PissedOff:
                waitTime = 3.0f;
                Debug.Log("In action state = " + state);
				break;
			case DevilAttack.Angry:
				Debug.Log("In action state = " + state);
                waitTime = 5.0f;
                break;
			case DevilAttack.Irritated:
                Debug.Log("In action state = " + state);
                waitTime = 6.0f;
                break;
			case DevilAttack.Annoyed:
                Debug.Log("In action state = " + state);
                waitTime = 7.0f;
                break;
			case DevilAttack.Harmless:
                waitTime = 8.0f;
                break;
            default:
                Debug.Log("In action state = " + state);
                break;
        }
    }

    private void initSpike(){
        anim.SetTrigger("throw");
        Instantiate(spike, throwPosition.position, transform.rotation);
        inAction = false;
    }

    private void initBowl(){
        anim.SetTrigger("bowl");
        Instantiate(bowl, BowlPosition.position, transform.rotation);
        inAction = false;
    }

	IEnumerator BiteAttack(Vector3 target)
	{
        
        while ((target.x - transform.position.x) > 0.05f && !hitPlayer)
		{
			transform.position += Vector3.right * speed * 0.5f * Time.deltaTime;
			Collider2D[] col = Physics2D.OverlapCircleAll(BowlPosition.position, 0.5f);
			foreach (Collider2D c in col)
			{
				if(c.tag == "Player" && !hitPlayer)
				{
					Player p = c.GetComponent<Player>();
					p.Damage();
					p.rb.velocity += (Vector2.up + Vector2.right) * 10f;
					hitPlayer = true;
                    anim.SetTrigger("bite");
                    break;
				}
			}
			yield return null;
		}
		StartCoroutine(BiteRetreat());
	}

	IEnumerator BiteRetreat()
	{
		StopCoroutine("BiteAttack");
		while ((transform.position.x - startPos.x) > 0.05f)
		{
			transform.position -= Vector3.right * speed * 0.7f * Time.deltaTime;
			yield return null;
		}
		hitPlayer = false;
        inAction = false;
        
        StopCoroutine(BiteRetreat());
	}


}
