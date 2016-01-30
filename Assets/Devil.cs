using UnityEngine;
using System.Collections;

public class Devil : MonoBehaviour {

	//We'll add many more if needed
	public enum DevilAttack : int
	{
		Bite = 0,
		Throw = 1,
		ThrowSpike = 2,
		Bowl = 3,
		Supersaiyan = 4
	}

	bool hitPlayer = false;

    bool reachedPosition;
    float posX;
    Vector3 startPos;
    bool inAction;
    public Transform spike;
    public Transform throwPosition;
    public Transform bowl;
    public Transform BowlPosition;

    public void setState(int state)
	{
        runAction((DevilAttack)state);
    }

    public Transform startMarker;
    public Transform endMarker;
	

    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;
    void Start()
    {
		startPos = transform.position;
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
        inAction = false;

    }
    void Update()
    {
        
    }

    public void runAction(DevilAttack state){
        if (inAction){
            return;
        }
        switch (state){
            case DevilAttack.Bite:
                inAction = true;
				StartCoroutine("BiteAttack", LocalDatabase.instance.player.transform.position);
                Debug.Log("In action state = " + state);
				break;
			case DevilAttack.Throw:
				Debug.Log("In action state = " + state);
				break;
			case DevilAttack.ThrowSpike:
                inAction = true;
                initSpike();
                Debug.Log("In action state = " + state);
				break;
			case DevilAttack.Bowl:
                inAction = true;
                initBowl();
                Debug.Log("In action state = " + state);
                break;
			case DevilAttack.Supersaiyan:
				break;
            default:
                Debug.Log("In action state = " + state);
                break;
        }
    }

    private void initSpike()
	{
        Instantiate(spike, throwPosition.position, transform.rotation);
        inAction = false;
    }

    private void initBowl()
	{
        Instantiate(bowl, BowlPosition.position, transform.rotation);
        inAction = false;
    }

	//I'll deal with this later on...
	IEnumerator BiteAttack(Vector3 target)
	{
		while ((target.x - transform.position.x) > 0.05f)
		{
			transform.position += Vector3.right * speed * 0.1f * Time.deltaTime;
			Collider2D[] col = Physics2D.OverlapCircleAll(BowlPosition.position, 0.5f);
			foreach (Collider2D c in col)
			{
				if(c.tag == "Player" && !hitPlayer)
				{
					Player p = c.GetComponent<Player>();
					p.Damage();
					p.rb.velocity += (Vector2.up + Vector2.right) * 10f;
					hitPlayer = true;
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
			transform.position -= Vector3.right * speed * 0.1f * Time.deltaTime;
			yield return null;
		}
		hitPlayer = false;
		StopCoroutine(BiteRetreat());
	}


}
