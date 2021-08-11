using UnityEngine;

public class Menu : MonoBehaviour
{
    void Awake()
    {
		if (PlayerPrefs.GetString("level01") == "")
		{
            Debug.Log("Creating PlayerPrefs");
            PlayerPrefs.SetString("level01", "unlocked");
		}
    }

    public void Quit() => Application.Quit();
}
