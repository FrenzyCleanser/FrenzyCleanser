using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
	bool isOver = false;

    public Text GUIpentagramCount;
	public Text TimeSpent;

    void OnEnable()
	{
		GameOver();
	}


	public void GameOver()
	{
        GUIpentagramCount.text =  LocalDatabase.instance.getPentagramCount().ToString();
		TimeSpent.text = Time.timeSinceLevelLoad.ToString() + " seconds lived";
		
        ShowPanels.instance.GetComponent<PlayMusic>().PlaySelectedMusic(0);
		//Set isPaused to true
		isOver = true;
		//Set time.timescale to 0, this will cause animations and physics to stop updating
		Time.timeScale = 0;
		//call the ShowPausePanel function of the ShowPanels script
	}

	public void Retry()
	{
		
		SceneManager.LoadScene("endless");
		ShowPanels.instance.GetComponent<PlayMusic>().PlaySelectedMusic(1);
        gameObject.SetActive(false);
		Time.timeScale = 1;
		//call the ShowPausePanel function of the ShowPanels script
	}

}
