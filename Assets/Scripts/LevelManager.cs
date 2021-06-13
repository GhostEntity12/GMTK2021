using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine;
using static Fade;

public class LevelManager : MonoBehaviour
{
	Goal[] goals;

	public CanvasGroup victoryScreen;

	public RectTransform prompt;
	public AnimationCurve promptCurve;
	float promptTime;

	public Object[] levelsToUnlock;

	private void Awake()
	{
		goals = GetComponentsInChildren<Goal>();
	}

	private void Update()
	{
		if (prompt)
		{
			prompt.anchoredPosition = new Vector2(promptCurve.Evaluate(promptTime), 0);
			promptTime += Time.deltaTime;
		}

		if (Input.GetButtonDown("Restart"))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

	public void CheckComplete()
	{
		foreach (Goal goal in goals)
		{
			if (!Physics.CheckBox(goal.transform.position + new Vector3(0, 0.3f, 0), new Vector3(0.6f, 0.6f, 0.6f), Quaternion.identity, 1 << goal.playerLayer)) return;
		}
		// Victory

		FindObjectsOfType<PlayerController>().ToList().ForEach(p => p.enabled = false);
		PlayerPrefs.SetString(SceneManager.GetActiveScene().name, "complete");
		foreach (Object level in levelsToUnlock)
		{
			if (PlayerPrefs.GetString(level.name) != "complete")
			{
				PlayerPrefs.SetString(level.name, "unlocked");
			}
		}

		StartCoroutine(FadeElement(victoryScreen, 0.5f, 0, 1, 0));

	}
}
