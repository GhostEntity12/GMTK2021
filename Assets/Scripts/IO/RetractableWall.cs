using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetractableWall : OutputObject
{
	new Collider collider;
	new MeshRenderer renderer;
	public bool isSolid = true;

	private void Awake()
	{
		collider = GetComponent<BoxCollider>();
		renderer = GetComponent<MeshRenderer>();
		collider.enabled = renderer.enabled = isSolid;
	}

	public override void Trigger() => Toggle();

	public override void Untrigger() => Toggle();

	void Toggle()
	{
		isSolid = !isSolid;
		collider.enabled = renderer.enabled = isSolid;
	}
}
