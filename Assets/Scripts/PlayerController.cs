using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	Vector3 direction;

	public float moveSpeed = 5f;
	public float speedModifier = 1f;
	public bool invertControl = false;
	private float turnSmoothVelocity;
	private readonly float turnSmoothTime = 0.1f;

	public Transform cameraContainer;

	new Rigidbody rigidbody;
	public LayerMask interactionLayer;

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
	}

	private void Update()
    {
		direction = UniformInput.GetAnalogStick();
		if (direction.magnitude > 1)
		{
			direction.Normalize();
		}
		if (Input.GetButtonDown("Interact"))
		{
			Physics.OverlapSphere(transform.position, 0.6f, interactionLayer).ToList().Where(c => c.GetComponent<Lever>()).Select(i => i.GetComponent<Lever>()).ToList().ForEach(l => l.Toggle());
		}
    }

	private void FixedUpdate()
	{
		if (direction.magnitude > 0)
		{
			float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraContainer.eulerAngles.y;
			float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
			transform.rotation = Quaternion.Euler(0f, angle, 0f);

			Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * (invertControl ? Vector3.back : Vector3.forward);
			rigidbody.velocity = moveSpeed * speedModifier * moveDirection;
		}
		else
		{
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
		}
	}
}

/// <summary>
///  Via https://amorten.com/blog/2017/mapping-square-input-to-circle-in-unity/, modified to use Vector3
/// </summary>
public static class UniformInput
{
	/// <summary>
	/// Remaps the horizontal/vertical input to a perfect circle instead of a square.
	/// This prevents the issue of characters speeding up when moving diagonally, but maintains the analog stick sensivity.
	/// </summary>
	public static Vector3 GetAnalogStick(string horizontal = "Horizontal", string vertical = "Vertical")
	{
		// apply some error margin, because the analog stick typically does not
		// reach the corner entirely
		const float error = 1.1f;
		// clamp input with error margin
		var input = new Vector3(
			Mathf.Clamp(Input.GetAxisRaw(horizontal) * error, -1f, 1f),
			0,
			Mathf.Clamp(Input.GetAxisRaw(vertical) * error, -1f, 1f)
		);
		// map square input to circle, to maintain uniform speed in all
		// directions
		return new Vector3(
			input.x * Mathf.Sqrt(1 - input.z * input.z * 0.5f),
			0,
			input.z * Mathf.Sqrt(1 - input.x * input.x * 0.5f)
		);
	}
}