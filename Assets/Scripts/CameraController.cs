using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotSpeed = 30;
    public float movSpeed = 10;
	Vector3 direction;

	public Collider boundingBox;
	Bounds bounds;

	private void Awake()
	{
		bounds = boundingBox.bounds;
	}

	// Update is called once per frame
	void Update()
    {
		transform.Rotate(Vector3.up, -Input.GetAxisRaw("Rotate") * rotSpeed * Time.deltaTime);

		direction = new Vector3(Input.GetAxis("CameraVertical"), 0, Input.GetAxis("CameraHorizontal"));
		if (direction.magnitude > 1)
		{
			direction.Normalize();
		}
		transform.position = bounds.ClosestPoint(transform.position + (transform.forward * direction.x + transform.right * direction.z) * movSpeed * Time.deltaTime);
	}
}
