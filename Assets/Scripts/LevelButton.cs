using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public Image icon;
    public Sprite padlock, star, starFilled;
    public Object scene;

    // Start is called before the first frame update
    void Start()
    {
		switch (PlayerPrefs.GetString(scene.name))
		{
            case "unlocked":
                icon.sprite = star;
                break;
            case "complete":
                icon.sprite = starFilled;
                break;
			default:
                icon.sprite = padlock;
                GetComponent<Button>().interactable = false;
				break;
		}
    }
    public void LoadLevel() => SceneManager.LoadScene(scene.name);
}
