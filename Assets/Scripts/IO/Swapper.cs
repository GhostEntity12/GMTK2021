using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Swapper : OutputObject
{
	PlayerController[] players;

	private void Awake()
	{
		players = FindObjectsOfType<PlayerController>();
	}

	public override void Trigger() => Swap();

	public override void Untrigger() => Swap();

	void Swap()
	{
		var oldPositions = new Queue<Vector3>(players.Select(p => p.transform.position));
		var firstPos = oldPositions.Dequeue();
		List<Vector3> newPositions = oldPositions.ToList();
		newPositions.Add(firstPos);
		Debug.Log(string.Join(", ", newPositions));

		for (int i = 0; i < newPositions.Count; i++)
		{
			players[i].transform.position = newPositions[i];
		}
	}
}
