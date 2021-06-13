using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : InputObject
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<PlayerController>() && (gameObject.layer == 8 || other.gameObject.layer == gameObject.layer)) 
		{
			Interact();
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.GetComponent<PlayerController>() && (gameObject.layer == 8 || other.gameObject.layer == gameObject.layer))
		{
			EndInteract();
		}
	}
}
