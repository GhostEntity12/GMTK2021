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
