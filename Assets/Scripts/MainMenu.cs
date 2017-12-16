using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string levelToLoad = "MainLevel";

	public SceneFader sceneFader;

	public void Play ()
	{
		sceneFader.FadeTo(levelToLoad);
	}

    public void Help()
    {
        sceneFader.FadeTo("Help");
    }

    public void Quit ()
	{
		Debug.Log("Exciting...");
		Application.Quit();
	}

}
