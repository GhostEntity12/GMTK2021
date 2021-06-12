using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public enum FaceDirection { Left, Right };
	public FaceDirection direction = FaceDirection.Right;
	public float rotateSpeed = 3;

	Crate crate;
	HingeJoint joint;
	public LineRenderer lineRenderer;

    private void Awake()
    {
		joint = GetComponent<HingeJoint>();        
    }

    // Update is called once per frame
    void Update()
    {
        float xMov = Input.GetAxis("Horizontal");
        float yMov = Input.GetAxis("Vertical");

		if (xMov > 0)
		{
			direction = FaceDirection.Right;
		}
		else if (xMov < 0)
		{
			direction = FaceDirection.Left;
		}

		if (Input.GetButtonDown("Fire1"))
		{
			if (crate)
			{
				joint.connectedBody = null;
				crate = null;
				Debug.Log("Dropping crate", crate);
			}
			else
			{
				Collider[] crates = Physics.OverlapBox(transform.position - Vector3.up * 2.5f, new Vector3(1, 2, 1), Quaternion.identity, 1 << 6);
				if (crates.Length > 0)
				{
					crate = crates[0].GetComponent<Crate>();
					joint.connectedBody = crate.rigidbody;
					Debug.Log("Grabbing crate", crate);
					// Harpoon the crate
				}
				else
				{
					Debug.Log("No crates found", crate);
				}
			}
		}
		Debug.DrawRay(transform.position, Vector3.RotateTowards(transform.forward, direction == FaceDirection.Right ? Vector3.forward : Vector3.back, rotateSpeed * Time.deltaTime, 0f));
		transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, direction == FaceDirection.Right ? Vector3.forward : Vector3.back, rotateSpeed * Time.deltaTime, 0f));

		if (crate)
		{
			lineRenderer.widthMultiplier = 0.1f; 
			lineRenderer.SetPositions(new Vector3[] { transform.position - Vector3.up * 0.5f, crate.transform.position + crate.transform.up * 0.5f });
		}
		else
		{
			lineRenderer.widthMultiplier = 0; 
		}
    }
}
