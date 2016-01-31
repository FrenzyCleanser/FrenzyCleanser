using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
	bool isOver = false;
	
	void OnEnable()
	{
		GameOver();
	}

	public void GameOver()
	{
		//Set isPaused to true
		isOver = true;
		//Set time.timescale to 0, this will cause animations and physics to stop updating
		Time.timeScale = 0;
		//call the ShowPausePanel function of the ShowPanels script
	}

	public void Retry()
	{
		SceneManager.LoadScene("endless");
		gameObject.SetActive(false);
		Time.timeScale = 1;
		//call the ShowPausePanel function of the ShowPanels script
	}

}
