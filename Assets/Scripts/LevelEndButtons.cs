using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndButtons : MonoBehaviour
{
	public Object nextLevel;

	public void LoadNextLevel() => SceneManager.LoadScene(nextLevel.name);

	public void ToMenu() => SceneManager.LoadScene(0);
}
