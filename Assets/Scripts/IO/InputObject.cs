using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputObject : MonoBehaviour
{
	public List<OutputObject> outputs;
	public virtual void Interact()
	{
		outputs.ForEach(o => o.Trigger());
	}
	public virtual void EndInteract()
	{
		outputs.ForEach(o => o.Untrigger());
	}
}
