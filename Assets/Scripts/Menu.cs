using UnityEngine;

public class Menu : MonoBehaviour
{
    void Awake()
    {
		if (PlayerPrefs.GetString("Tutorial1") == "")
		{
            Debug.Log("Creating PlayerPrefs");
            PlayerPrefs.SetString("Tutorial1", "unlocked");
		}
    }

    public void Quit() => Application.Quit();
}
