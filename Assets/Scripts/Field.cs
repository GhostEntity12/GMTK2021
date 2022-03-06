using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
	public enum FieldType { SpeedUp, SpeedDown, Inversion }
	public FieldType fieldType;

	private void Awake()
	{
		// Set up field appearance
	}

	private void OnTriggerEnter(Collider other)
	{
		PlayerController p = other.GetComponent<PlayerController>();
		if (p)
		{
			switch (fieldType)
			{
				case FieldType.SpeedUp:
					p.speedModifier = 1.5f;
					break;
				case FieldType.SpeedDown:
					p.speedModifier = 0.667f;
					break;
				case FieldType.Inversion:
					p.invertControl = true;
					break;
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		PlayerController p = other.GetComponent<PlayerController>();
		if (p)
		{
			switch (fieldType)
			{
				case FieldType.SpeedUp:
				case FieldType.SpeedDown:
					p.speedModifier = 1f;
					break;
				case FieldType.Inversion:
					p.invertControl = false;
					break;
			}
		}
	}
}
