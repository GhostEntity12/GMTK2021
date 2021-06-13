using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : InputObject
{
	bool on = false;

	public void Toggle()
	{
		on = !on;
		if (on)
		{
			Interact();
		}
		else
		{
			EndInteract();
		}
	}
}
