using UnityEngine;

public class Lever : InputObject
{
	bool on = false;
	public Transform lever;

	private void Awake()
	{
		lever.localRotation = Quaternion.Euler(-75, 0, 0);
	}

	public void Toggle()
	{
		on = !on;
		lever.localRotation = Quaternion.Euler(-lever.localRotation.eulerAngles.x, 0, 0);
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
