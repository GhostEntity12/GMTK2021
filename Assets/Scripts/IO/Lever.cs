using UnityEngine;

public class Lever : InputObject
{
	bool on = false;
	public Transform lever;
	AudioSource audioSource;
	public AudioClip leverPullSound;
	private void Awake()
	{
		lever.localRotation = Quaternion.Euler(-75, 0, 0);
		audioSource = FindObjectOfType<AudioSource>();
	}

	public void Toggle()
	{
		on = !on;
		lever.localRotation = Quaternion.Euler(-lever.localRotation.eulerAngles.x, 0, 0);
		audioSource.PlayOneShot(leverPullSound);
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
