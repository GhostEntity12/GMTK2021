using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputObject : MonoBehaviour
{
	public OutputObject output;
	public virtual void Interact()
	{
		output.Trigger();
	}
	public virtual void EndInteract()
	{
		output.Untrigger();
	}
}
