using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static bool GameIsOver;

	public GameObject gameOverUI;
	public GameObject completeLevelUI;

	void Start ()
	{
		GameIsOver = false;
	}

	// Update is called once per frame
	void Update () {
		if (GameIsOver)
			return;

		if (PlayerStats.Lives <= 0)
		{
			EndGame();
		}
	}

	void EndGame ()
	{
		if(!GameIsOver)
        {
            GameIsOver = true;
            gameOverUI.SetActive(true);
        }
	}

	public void WinLevel ()
	{
		if(!GameIsOver)
        {
            GameIsOver = true;
            completeLevelUI.SetActive(true);
        }
	}

}
