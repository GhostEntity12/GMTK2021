using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetractableWall : OutputObject
{
	new Collider collider;
	new MeshRenderer renderer;
	bool isPassable;

	private void Awake()
	{
		collider = GetComponent<BoxCollider>();
		renderer = GetComponent<MeshRenderer>();
	}

	public override void Trigger() => Toggle();

	public override void Untrigger() => Toggle();

	void Toggle()
	{
		collider.enabled = renderer.enabled = isPassable;
		isPassable = !isPassable;

	}
}
