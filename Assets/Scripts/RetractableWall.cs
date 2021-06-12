using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetractableWall : OutputObject
{
	new Collider collider;
	new MeshRenderer renderer;

	private void Awake()
	{
		collider = GetComponent<BoxCollider>();
		renderer = GetComponent<MeshRenderer>();
	}

	public override void Trigger()
	{
		collider.enabled = renderer.enabled = false;
	}

	public override void Untrigger()
	{
		collider.enabled = renderer.enabled = true;
	}
}
