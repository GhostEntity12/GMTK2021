using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	Goal[] goals;

	public Object[] levelsToUnlock;
	private void Awake()
	{
		goals = GetComponentsInChildren<Goal>();
	}

	public void CheckComplete()
	{
		foreach (Goal goal in goals)
		{
			if (!Physics.CheckBox(goal.transform.position + new Vector3(0, 0.3f, 0), new Vector3(0.6f, 0.6f, 0.6f), Quaternion.identity, 1 << goal.playerLayer)) return;
		}
		// Victory
		PlayerPrefs.SetString(SceneManager.GetActiveScene().name, "complete");
		foreach (Object level in levelsToUnlock)
		{
			if (PlayerPrefs.GetString(level.name) != "complete")
			{
				PlayerPrefs.SetString(level.name, "unlocked");
			}
		}
	}
}
