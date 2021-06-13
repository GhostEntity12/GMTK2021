using UnityEngine;

public class PressurePlate : InputObject
{
	public Transform button;

	private void OnTriggerEnter(Collider other)
	{
		PlayerController player = other.GetComponent<PlayerController>();
		if (player && (gameObject.layer == 31 || player.interactionLayer == (player.interactionLayer | 1 << gameObject.layer))) 
		{
			Interact();
			button.position = transform.position + new Vector3(0, -0.075f, 0);
		}
	}
	private void OnTriggerExit(Collider other)
	{
		PlayerController player = other.GetComponent<PlayerController>();
		if (player && (gameObject.layer == 31 || player.interactionLayer == (player.interactionLayer | 1 << gameObject.layer)))
		{
			EndInteract();
			button.position = transform.position;
		}
	}
}
