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

    float waitTime;
    bool inBite;
    bool reachedPosition;
    float posX;
    Vector3 startPos;
    Vector3 endPos;
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
    void Start() {
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
        inAction = false;
        waitTime = 5.0f;
        StartCoroutine(runAction());       
    }

    IEnumerator runAction(){
        while (true){
            yield return new WaitForSeconds(waitTime);
            var randomInt = Random.Range(0, 3);
            inAction = true;
            if (randomInt == 0){
                inBite = true;
            }
            else if(randomInt == 1){
                initSpike();
            }
            else if(randomInt == 2){
                initBowl();
            }
            Debug.Log("running action. Delay = " + waitTime);
        }
    
}

void Update()
    {
        if (inBite){
            if (!reachedPosition){
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, endMarker.position, step);
                if (transform.position.x >= endMarker.position.x - .05f){
                    reachedPosition = true;
                }
            }
            else{
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, startMarker.position, step);
                if (transform.position.x <= startMarker.position.x + .05f){
                    reachedPosition = false;
                    inBite = false;
                    inAction = false;
                }
            }
        }
    }

    public void runAction(DevilAttack state){
        if (inAction){
            return;
        }
        switch (state){
            case DevilAttack.PissedOff:
                waitTime = 3.0f;
                Debug.Log("In action state = " + state);
				break;
			case DevilAttack.Angry:
				Debug.Log("In action state = " + state);
                waitTime = 6.0f;
                break;
			case DevilAttack.Irritated:
                Debug.Log("In action state = " + state);
                waitTime = 8.0f;
                break;
			case DevilAttack.Annoyed:
                Debug.Log("In action state = " + state);
                waitTime = 10.0f;
                break;
			case DevilAttack.Harmless:
                waitTime = 12.0f;
                break;
            default:
                Debug.Log("In action state = " + state);
                break;
        }
    }

    private void initSpike(){
        Instantiate(spike, throwPosition.position, transform.rotation);
        inAction = false;
    }

    private void initBowl(){
        Instantiate(bowl, BowlPosition.position, transform.rotation);
        inAction = false;
    }

	//I'll deal with this later on...
	IEnumerator BiteAttack(){
		while (true)
		{
			yield return null;
        }
	}

}
