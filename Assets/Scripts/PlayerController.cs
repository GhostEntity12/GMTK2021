using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	Vector3 direction;

	public float moveSpeed = 5f;
	private float turnSmoothVelocity;
	private readonly float turnSmoothTime = 0.1f;

	public Transform cameraContainer;

	new Rigidbody rigidbody;
	public int interactionLayer;

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
		interactionLayer = 1 << gameObject.layer | 1 << 8;
	}

	private void Update()
    {
		direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
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

			Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
			rigidbody.velocity = moveDirection * moveSpeed;
		}
		else
		{
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
		}
	}
}
