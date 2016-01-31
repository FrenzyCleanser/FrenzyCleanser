using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LocalDatabase : MonoBehaviour {

	static LocalDatabase _instance;
	public static LocalDatabase instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType<LocalDatabase>();
			}
			return _instance;
		}
	}

    private int pentagramCount = 0;
    int currentState = 2;
    int newState = 2;
    public int mana = 100;
    private float apocalypseMax = 100;
    public float apocalypseCurrent = 50;

	public Image apocalypsoMeter;
	public Image healthBar;
	public Player player;
    public Devil devil;
	


    public int getPentagramCount()
    {
        return pentagramCount;
    }

    public void Start()
	{
		apocalypsoMeter.fillAmount = apocalypseNormalized;
       
    }

    //for testing;
    public void Update()
	{
	
	}

    public float apocalypseNormalized { get { return apocalypseCurrent / apocalypseMax; } }

    public void addApocalypse(float addValue){
        apocalypseCurrent += addValue;
		updateApocalypse();
	}
	public void removeApocalypse(float removeValue)
	{
		apocalypseCurrent -= removeValue;
		updateApocalypse();
	}

	void updateApocalypse()
	{
		checkDevilState();
        apocalypsoMeter.fillAmount = apocalypseNormalized;

		if(apocalypseCurrent >= apocalypseMax)
		{
			ShowPanels.instance.ShowGameOverPanel();
		}
	}

	float[,] devilList = new float[5, 2] { { -1000, 0.2f }, { 0.2f, .4f }, { .4f, .6f }, { .6f, .8f }, { .8f, 1000 } };

    private void checkDevilState(){
        if(apocalypseNormalized < devilList[currentState, 0]){
            currentState--;
            devil.setState(currentState);
        }
        else if(apocalypseNormalized > devilList[currentState, 1]){
            currentState++;
            devil.setState(currentState);
        }
    }

    public void addPentagramCount()
    {
        pentagramCount++;
    }
}
