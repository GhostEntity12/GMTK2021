using UnityEngine;

public class Menu : MonoBehaviour
{
    void Awake()
    {
		if (PlayerPrefs.GetString("level1") == "")
		{
            Debug.Log("Creating PlayerPrefs");
            PlayerPrefs.SetString("level1", "unlocked");
		}
    }

    public void Quit() => Application.Quit();
}
