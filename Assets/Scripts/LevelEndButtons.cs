using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndButtons : MonoBehaviour
{
	public string nextLevel;

	public void LoadNextLevel() => SceneManager.LoadScene(nextLevel);

	public void ToMenu() => SceneManager.LoadScene(0);
}
