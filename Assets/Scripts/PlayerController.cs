using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	Vector3 direction;

	public float moveSpeed = 5f;
	private float turnSmoothVelocity;
	private readonly float turnSmoothTime = 0.1f;

	public Transform cameraContainer;

	new Rigidbody rigidbody;

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
	}

	private void Update()
    {
		direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		if (direction.magnitude > 1)
		{
			direction.Normalize();
		}
    }

	private void FixedUpdate()
	{
		if (direction.magnitude > 0)
		{
			float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraContainer.eulerAngles.y;
			float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
			transform.rotation = Quaternion.Euler(0f, angle, 0f);

			Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
			Debug.Log(moveDirection);
			rigidbody.velocity = moveDirection * moveSpeed;
		}
		else
		{
			rigidbody.velocity = Vector3.zero;
		}
	}
}
