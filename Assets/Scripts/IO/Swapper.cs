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
		var positions = new Queue<Vector3>(players.Select(p => p.transform.position));
		positions.Enqueue(positions.Dequeue());

		var newPositions = positions.ToList();
		for (int i = 0; i < newPositions.Count; i++)
		{
			players[i].transform.position = newPositions[i];
		}
	}
}
