using UnityEngine;

public class PressurePlate : InputObject
{
	public Transform button;
	AudioSource audioSource;
	public AudioClip pressureplateTriggerSound;

	private void Awake()
	{
		audioSource = FindObjectOfType<AudioSource>();
	}

	private void OnTriggerEnter(Collider other)
	{
		PlayerController player = other.GetComponent<PlayerController>();
		if (player && (gameObject.layer == 31 || player.interactionLayer == (player.interactionLayer | 1 << gameObject.layer))) 
		{
			Interact();
			audioSource.PlayOneShot(pressureplateTriggerSound, 0.5f);
			button.position = transform.position + new Vector3(0, -0.075f, 0);
		}
	}
	private void OnTriggerExit(Collider other)
	{
		PlayerController player = other.GetComponent<PlayerController>();
		if (player && (gameObject.layer == 31 || player.interactionLayer == (player.interactionLayer | 1 << gameObject.layer)))
		{
			EndInteract();
			audioSource.PlayOneShot(pressureplateTriggerSound, 0.5f);
			button.position = transform.position;
		}
	}
}
