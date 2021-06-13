using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
	public int playerLayer;
	LevelManager levelComplete;

	private void Awake()
	{
		levelComplete = transform.parent.GetComponent<LevelManager>();
	}

	private void OnTriggerEnter(Collider other)
	{
		PlayerController player = other.GetComponent<PlayerController>();
		if (player && player.gameObject.layer == playerLayer)
		{
			levelComplete.CheckComplete();
		}
	}
}
